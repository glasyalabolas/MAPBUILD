Option Infer On

Imports ClipperLib
Imports System.Drawing.Drawing2D

Imports Polygon = System.Collections.Generic.List(Of ClipperLib.IntPoint)
Imports Polygons = System.Collections.Generic.List(
  Of System.Collections.Generic.List(Of ClipperLib.IntPoint))

Public Class ClipperTest
  Private subjects = New Polygons()
  Private clips = New Polygons()
  Private solution = New Polygons()

  '' Here we are scaling all coordinates up by 100 when they're passed
  '' to Clipper via Polygon (Or Polygons) objects because Clipper no
  '' longer accepts floating point values. Likewise when Clipper returns
  '' a solution in a Polygons object, we need to scale down these
  '' returned values by the same amount before displaying.
  Private clipperScale As Single = 100.0

  Private Function PolygonToPointFArray(pg As Polygon, scale As Single) As PointF()
    Dim result(0 To pg.Count - 1) As PointF

    For i As Integer = 0 To pg.Count - 1
      result(i) = New PointF(pg(i).X / scale, pg(i).Y / scale)
    Next

    Return (result)
  End Function

  Private Function GenerateRandomPoint(l As Integer, t As Integer, r As Integer, b As Integer, rand As Random) As IntPoint
    Dim Q As Integer = 10

    Return (New IntPoint(
      Convert.ToInt64((rand.Next(r / Q) * Q + l + 10) * clipperScale),
      Convert.ToInt64((rand.Next(b / Q) * Q + t + 10) * clipperScale)))
  End Function

  Private Sub GenerateRandomPolygon(count As Integer)
    Dim Q As Integer = 10
    Dim rand = New Random()

    Dim l As Integer = 10
    Dim t As Integer = 10
    Dim r As Integer = (PictureBox1.ClientRectangle.Width - 20) / Q * Q
    Dim b As Integer = (PictureBox1.ClientRectangle.Height - 20) / Q * Q

    subjects.clear()
    clips.clear()

    Dim subj = New Polygon(count)

    For i As Integer = 0 To count - 1
      subj.Add(GenerateRandomPoint(l, t, r, b, rand))
    Next

    subjects.add(subj)

    Dim clip = New Polygon(count)

    For i As Integer = 0 To count - 1
      clip.Add(GenerateRandomPoint(l, t, r, b, rand))
    Next

    clips.add(clip)
  End Sub

  Private Function GetClipType() As ClipType
    If (rbIntersect.Checked) Then Return (ClipType.ctIntersection)
    If (rbUnion.Checked) Then Return (ClipType.ctUnion)
    If (rbDifference.Checked) Then Return (ClipType.ctDifference)
    Return (ClipType.ctXor)
  End Function

  Private Function GetPolyFillType() As PolyFillType
    If (rbNonZero.Checked) Then Return (PolyFillType.pftNonZero)
    Return (PolyFillType.pftEvenOdd)
  End Function

  Private Sub DrawBitmap(Optional justClip As Boolean = False)
    If (Not justClip) Then
      GenerateRandomPolygon(nudCount.Value)
    End If

    Dim myBitmap = New Bitmap(
      PictureBox1.ClientRectangle.Width,
      PictureBox1.ClientRectangle.Height)

    Dim newGraphic = Graphics.FromImage(myBitmap)
    Dim path = New GraphicsPath()

    newGraphic.SmoothingMode = SmoothingMode.AntiAlias
    newGraphic.Clear(Color.White)

    If (rbNonZero.Checked) Then
      path.FillMode = FillMode.Winding
    End If

    '' Draw subjects
    For Each pg As Polygon In subjects
      Dim pts = PolygonToPointFArray(pg, clipperScale)

      path.AddPolygon(pts)
      pts = Nothing
    Next

    Dim myPen = New Pen(Color.FromArgb(196, &HC3, &HC9, &HCF), 0.6)
    Dim myBrush = New SolidBrush(Color.FromArgb(127, &HDD, &HDD, &HF0))

    newGraphic.FillPath(myBrush, path)
    newGraphic.DrawPath(myPen, path)

    path.Reset()

    '' Draw clips
    If (rbNonZero.Checked) Then
      path.FillMode = FillMode.Winding
    End If

    For Each pg As Polygon In clips
      Dim pts = PolygonToPointFArray(pg, clipperScale)
      path.AddPolygon(pts)
      pts = Nothing
    Next

    myPen.Color = Color.FromArgb(196, &HF9, &HBE, &HA6)
    myBrush.Color = Color.FromArgb(127, &HFF, &HE0, &HE0)

    newGraphic.FillPath(myBrush, path)
    newGraphic.DrawPath(myPen, path)

    '' Do the clipping
    If (clips.count > 0 OrElse subjects.count > 0) Then
      Dim c = New Clipper()

      c.AddPaths(subjects, PolyType.ptSubject, True)
      c.AddPaths(clips, PolyType.ptClip, True)

      solution.clear()

      Dim suceeded = c.Execute(
        GetClipType(), solution, GetPolyFillType(), GetPolyFillType())

      If (suceeded) Then
        myBrush.Color = Color.Black

        path.Reset()
        path.FillMode = FillMode.Winding

        For Each pg As Polygon In solution
          Dim pts = PolygonToPointFArray(pg, clipperScale)

          If (pts.Count > 2) Then
            path.AddPolygon(pts)
          End If

          pts = Nothing
        Next

        myBrush.Color = Color.FromArgb(127, &H66, &HEF, &H7F)
        myPen.Color = Color.FromArgb(255, 0, &H33, 0)
        myPen.Width = 1.0F

        newGraphic.FillPath(myBrush, path)
        newGraphic.DrawPath(myPen, path)
      End If
    End If

    PictureBox1.Image = myBitmap
  End Sub

  Private Sub ClipperTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    DrawBitmap()
  End Sub

  Private Sub rbEvenOdd_CheckedChanged(sender As Object, e As EventArgs) Handles rbEvenOdd.CheckedChanged
    DrawBitmap(True)
  End Sub

  Private Sub rbNonZero_CheckedChanged(sender As Object, e As EventArgs) Handles rbNonZero.CheckedChanged
    DrawBitmap(True)
  End Sub
End Class