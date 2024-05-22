Option Infer On

Imports MAP_ID = System.Int32

Public Class SectorMode
  Inherits ModeBase

  Public Sub New()
    SetName("Sector mode")
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys)
    Dim p = Camera.ViewToWorld(New Vec2(e.X, e.Y))

    Dim sID As MAP_ID = NOT_FOUND

    '_highlightedSectorId = NOT_FOUND

    For i As Integer = 0 To Layer.Sectors - 1
      If (Layer.Sector(i).IsClosed()) Then
        If (Layer.Sector(i).Inside(p)) Then
          sID = Layer.Sector(i).Id
          Exit For
          '_highlightedSectorId = Layer.Sector(i).Id

          'OnModeEvent(Layer.SectorById(_highlightedSectorId),
          '  ModeEventType.EVENT_SECTOR_HIGHLIGHTED)

          'SetHelpText("Sector #: " & Layer.Sector(i).Id)
        End If
      End If
    Next

    If (sID <> _highlightedSectorId) Then
      _highlightedSectorId = sID

      If (_highlightedSectorId <> NOT_FOUND) Then
        OnModeEvent(Layer.SectorById(_highlightedSectorId),
          ModeEventType.EVENT_SECTOR_HIGHLIGHTED)

        SetHelpText("Sector #: " & Layer.SectorById(_highlightedSectorId).Id)
      End If
    End If
  End Sub

  Private Sub RenderSector(g As Graphics, s As Sector, T As Mat3, c As Color)
    For j As Integer = 0 To s.LineDefs - 1
      Dim ld = Layer.LineDefById(s.LineDef(j))

      Dim p0 = T * ld.GetP0().Pos
      Dim p1 = T * ld.GetP1().Pos

      RenderLineDef(g, p0, p1, c)
    Next
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    MyBase.OnRender(g)

    Dim T = Camera.Projection() * Camera.Transform().Inversed()

    For i As Integer = 0 To Layer.Sectors - 1
      RenderSector(g, Layer.Sector(i), T, VGAColors.Red)
    Next

    If (_highlightedSectorId <> NOT_FOUND) Then
      RenderSector(g, Layer.SectorById(_highlightedSectorId), T, VGAColors.Yellow)
    End If
  End Sub

  Public Overrides Sub OnKeyPress(e As KeyEventArgs, modifierKeys As Keys)
    If (_highlightedSectorId <> NOT_FOUND) Then
      Dim s = Layer.SectorById(_highlightedSectorId)

      If (e.KeyCode = Keys.Q) Then
        s.Rotate(Rad(-15))
      End If

      If (e.KeyCode = Keys.W) Then
        s.Rotate(Rad(15))
      End If
    End If

    OnRefresh()
  End Sub

  Private _highlightedSectorId As Integer = NOT_FOUND
End Class
