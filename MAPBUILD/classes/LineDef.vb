Option Infer On

Imports MAP_ID = System.Int32

Public Class LineDef
  Public Event LineDefSplit(sender As LineDef, newId As MAP_ID)
  Public Event LineDefDeleted(sender As LineDef)

  Public Sub OnLineDefSplit(newId As MAP_ID)
    RaiseEvent LineDefSplit(Me, newId)
  End Sub

  Public Sub OnLineDefDeleted()
    RaiseEvent LineDefDeleted(Me)
  End Sub

  Public Sub New()
    P0 = -1 : P1 = -1
  End Sub

  Public Sub New(nP0 As MAP_ID, nP1 As MAP_ID)
    P0 = nP0 : P1 = nP1
  End Sub

  Public Sub New(nId As MAP_ID, nP0 As MAP_ID, nP1 As MAP_ID)
    Id = nId : P0 = nP0 : P1 = nP1
  End Sub

  Public ReadOnly Property GetP0() As Vertex
    Get
      Return (Layer.VertexById(P0))
    End Get
  End Property

  Public ReadOnly Property GetP1() As Vertex
    Get
      Return (Layer.VertexById(P1))
    End Get
  End Property

  Public Function Length() As Single
    Return ((Layer.VertexById(P1).Pos - Layer.VertexById(P0).Pos).Length)
  End Function

  Public Function LengthSq() As Single
    Return ((Layer.VertexById(P1).Pos - Layer.VertexById(P0).Pos).LengthSq)
  End Function

  Public Function Interpolate(t As Single) As Vec2
    Return (((1.0! - t) * Layer.VertexById(P0).Pos + t * Layer.VertexById(P1).Pos))
  End Function

  Public Function Normal() As Vec2
    Return ((Layer.VertexById(P0).Pos - Layer.VertexById(P1).Pos).Normalize().TurnLeft())
  End Function

  Public Function PointTo(p As Vec2) As LineDef
    Dim dir = (p - Layer.VertexById(P0).Pos).Normalize()

    Layer.VertexById(P1).Pos = New Vec2(Layer.VertexById(P0).Pos + dir * Length())

    Return (Me)
  End Function

  Public Function Direction() As Vec2
    Return ((Layer.VertexById(P1).Pos - Layer.VertexById(P0).Pos).Normalize)
  End Function

  Public Function LookAt(p As Vec2) As LineDef
    Dim midPoint = Layer.VertexById(P0).Pos.Interpolated(Layer.VertexById(P1).Pos, 0.5!)
    Dim normal = (p - midPoint).Normalize()
    Dim dir = normal.TurnLeft()

    Dim hl As Single = Length() * 0.5!

    Layer.VertexById(P0).Pos = midPoint - dir * hl
    Layer.VertexById(P1).Pos = midPoint + dir * hl

    Return (Me)
  End Function

  Public Function GetClosestPoint(p As Vec2) As Vec2
    Dim lsq As Single = LengthSq()

    If (lsq = 0) Then
      Return (Layer.VertexById(P0).Pos.Clone())
    End If

    Dim u As Single = Math.Clamp(
      ((p.x - Layer.VertexById(P0).Pos.x) * (Layer.VertexById(P1).Pos.x - Layer.VertexById(P0).Pos.x) +
        (p.y - Layer.VertexById(P0).Pos.y) * (Layer.VertexById(P1).Pos.y - Layer.VertexById(P0).Pos.y)) / lsq,
        0.0!, 1.0!)

    Return (New Vec2(
      Layer.VertexById(P0).Pos.x + u * (Layer.VertexById(P1).Pos.x - Layer.VertexById(P0).Pos.x),
      Layer.VertexById(P0).Pos.y + u * (Layer.VertexById(P1).Pos.y - Layer.VertexById(P0).Pos.y)))
  End Function

  Public Function Intersects(ld As LineDef, ByRef outP As Vec2,
    Optional ByRef ua As Single = 0.0, Optional ByRef ub As Single = 0.0) As Boolean

    Dim lP0 = Layer.VertexById(P0).Pos
    Dim lP1 = Layer.VertexById(P1).Pos

    Dim oP0 = Layer.VertexById(ld.P0).Pos
    Dim oP1 = Layer.VertexById(ld.P1).Pos

    Dim den As Single =
      (oP1.y - oP0.y) * (lP1.x - lP0.x) - (oP1.x - oP0.x) * (lP1.y - lP0.y)

    If (den = 0) Then Return (False)

    ua = ((oP1.x - oP0.x) * (lP0.y - oP0.y) - (oP1.y - oP0.y) * (lP0.x - oP0.x)) / den
    ub = ((lP1.x - lP0.x) * (lP0.y - oP0.y) - (lP1.y - lP0.y) * (lP0.x - oP0.x)) / den

    If (ua >= 0 AndAlso ua <= 1 AndAlso ub >= 0 AndAlso ub <= 1) Then
      outP = New Vec2(lP0.x + ua * (lP1.x - lP0.x), lP0.y + ua * (lP1.y - lP0.y))
      Return (True)
    End If

    Return (False)
  End Function

  Public Function Traverse(s As Single) As List(Of Point)
    Dim mP0 = Layer.VertexById(P0)
    Dim mP1 = Layer.VertexById(P1)

    Dim x0 As Single = mP0.Pos.x
    Dim y0 As Single = mP0.Pos.y
    Dim x1 As Single = mP1.Pos.x
    Dim y1 As Single = mP1.Pos.y

    Dim cs As Single = 1.0F / s
    Dim posX As Single = x0 * cs
    Dim posY As Single = y0 * cs
    Dim rayDirX As Single = (x1 - x0)
    Dim rayDirY As Single = (y1 - y0)
    Dim deltaDistX As Single = IIf(rayDirY = 0,
      0, IIf(rayDirX = 0, 100000000.0, Math.Abs(1.0F / rayDirX)))
    Dim deltaDistY As Single = IIf(rayDirX = 0,
      0, IIf(rayDirY = 0, 100000000.0, Math.Abs(1.0F / rayDirY)))

    Dim mapX As Integer = Int(x0 * cs)
    Dim mapY As Integer = Int(y0 * cs)
    Dim endX As Integer = Int(x1 * cs)
    Dim endY As Integer = Int(y1 * cs)
    Dim n As Integer = 1 + (Math.Abs(endX - mapX)) + (Math.Abs(endY - mapY))

    Dim stepX As Integer = IIf(rayDirX < 0, -1, 1)
    Dim stepY As Integer = IIf(rayDirY < 0, -1, 1)

    Dim sideDistX As Single = IIf(rayDirX < 0,
      (posX - mapX) * deltaDistX, ((mapX + 1) - posX) * deltaDistX)
    Dim sideDistY As Single = IIf(rayDirY < 0,
      (posY - mapY) * deltaDistY, ((mapY + 1) - posY) * deltaDistY)

    Dim result As New List(Of Point)

    For i As Integer = 0 To n - 1
      result.Add(New Point(mapX, mapY))

      If (sideDistX < sideDistY) Then
        sideDistX += deltaDistX
        mapX += stepX
      Else
        sideDistY += deltaDistY
        mapY += stepY
      End If
    Next

    Return (result)
  End Function

  Public Sub Swap()
    Dim tmp = P0
    P0 = P1
    P1 = tmp
  End Sub

  Public Function FacesInside(s As Sector) As Boolean
    Dim result As Boolean = False

    For i As Integer = 0 To s.LineDefs - 1
      Dim ld = s.GetLineDef(i)

      If (ld.Id = Id) Then
        Dim p0 = GetP0()
        Dim p1 = GetP1()

        Dim N = Normal()
        Dim center = (p0.Pos + (p1.Pos - p0.Pos) * 0.5)

        If (s.Inside(center + N)) Then
          Return (True)
        End If
      End If
    Next

    Return (result)
  End Function

  Public P0 As MAP_ID
  Public P1 As MAP_ID
  Public Id As MAP_ID
  Public FrontSector As MAP_ID = -1
  Public BackSector As MAP_ID = -1
  Public Layer As Layer
End Class
