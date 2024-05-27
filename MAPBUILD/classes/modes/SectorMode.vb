Option Infer On

Imports MAP_ID = System.Int32

Public Class SectorMode
  Inherits ModeBase

  Public Sub New()
    SetName("Sector mode")
  End Sub

  Public Overrides Sub OnMouseMove(e As MouseEventArgs, modifierKeys As Keys)
    _mp = Camera.ViewToWorld(New Vec2(e.X, e.Y))

    Dim sID As MAP_ID = Layer.PointInSector(_mp)

    If (sID <> _highlightedSectorId AndAlso Not Selecting AndAlso Not _ldragging) Then
      _highlightedSectorId = sID

      If (_highlightedSectorId <> NOT_FOUND) Then
        OnModeEvent(Layer.SectorById(_highlightedSectorId),
          ModeEventType.EVENT_SECTOR_HIGHLIGHTED)

        SetHelpText("Sector #: " & Layer.SectorById(_highlightedSectorId).Id)
      End If
    End If

    If (_highlightedSectorId = NOT_FOUND) Then
      MyBase.OnMouseMove(e, modifierKeys)
    End If
  End Sub

  Private Sub RenderSector(g As Graphics, s As Sector, T As Mat3, c As Color)
    For j As Integer = 0 To s.LineDefs - 1
      Dim ld = Layer.LineDefById(s.LineDef(j))

      Dim p0 = T * ld.GetP0().Pos
      Dim p1 = T * ld.GetP1().Pos

      RenderLineDef(g, p0, p1, 10.0 / Camera.Zoom, c)
    Next
  End Sub

  Public Overrides Sub OnRender(g As Graphics)
    MyBase.OnRender(g)

    Dim T = Camera.Projection() * Camera.Transform().Inversed()

    For i As Integer = 0 To Layer.Sectors - 1
      RenderSector(g, Layer.Sector(i), T, VGAColors.DarkGray)
    Next

    If (_highlightedSectorId <> NOT_FOUND) Then
      RenderSector(g, Layer.SectorById(_highlightedSectorId), T, VGAColors.Yellow)
    End If

    RenderVertices(g, VGAColors.DarkGray)
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

      If (e.KeyCode = Keys.PageDown) Then
        Layer.BringToFront(_highlightedSectorId)
        SetHelpText("Sector #" & _highlightedSectorId & " brought to front")
      End If

      If (e.KeyCode = Keys.PageUp) Then
        Layer.SendToBack(_highlightedSectorId)
        SetHelpText("Sector #" & _highlightedSectorId & " sent to back")
      End If
    End If

    OnRefresh()
  End Sub

  Protected Overrides Sub OnSelect(e As Rect, modifierKeys As Keys)

  End Sub

  Private _highlightedSectorId As Integer = NOT_FOUND
  Private _ldelta As Vec2
  Private _lstart As Vec2
  Private _mp As New Vec2()
  Private _ldragging As Boolean
End Class
