Option Infer On

''' <summary>
''' Defines a map as consumed by an external engine.
''' </summary>
Public Class Map
  Public Event SelectedLayerChanged(sender As Object, e As SelectedLayerChangedEventArgs)

  Public Sub New()
    AddLayer()
    EnableEvents()
    SelectLayer(_layer.Count - 1)
  End Sub

  Public ReadOnly Property Layers() As Integer
    Get
      Return (_layer.Count)
    End Get
  End Property

  Public ReadOnly Property SelectedLayerIndex() As Integer
    Get
      Return (_selectedLayer)
    End Get
  End Property

  Public ReadOnly Property SelectedLayer() As Layer
    Get
      Return (_layer(_selectedLayer))
    End Get
  End Property

  Public Function AddLayer() As Layer
    Dim l = New Layer()

    _layer.Add(l)

    l.Name = "Layer" & _layer.Count

    Return (l)
  End Function

  Public Sub SelectLayer(index As Integer)
    _selectedLayer = index

    If (_raiseEvents) Then
      RaiseEvent SelectedLayerChanged(Me, New SelectedLayerChangedEventArgs() With {
        .Layer = _layer(_selectedLayer)})
    End If
  End Sub

  Public Sub EnableEvents()
    _raiseEvents = True
  End Sub

  Public Sub DisableEvents()
    _raiseEvents = False
  End Sub

  Public Function IsClosestVertex(v1 As Vec2, v2 As Vec2) As Boolean
    Dim closest = Integer.MaxValue
    Dim closestV As New Vec2

    For i As Integer = 0 To SelectedLayer.Vertices - 1
      Dim dist = v2.DistanceToSq(SelectedLayer.Vertex(i))

      If (dist < closest) Then
        closest = dist
        closestV = SelectedLayer.Vertex(i)
      End If
    Next

    Return (closestV.x = v1.x AndAlso closestV.y = v1.y)
  End Function

  Private _layer As New List(Of Layer)
  Private _selectedLayer As Integer
  Private _raiseEvents As Boolean
End Class
