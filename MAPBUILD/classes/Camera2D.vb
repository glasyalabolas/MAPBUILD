﻿Option Infer On

Public Class Camera2D
  Public Sub New()
  End Sub

  Public Sub New(viewWidth As Single, viewHeight As Single)
    ViewPort = New Vec2(viewWidth, viewHeight)
  End Sub

  Public Property ViewPort() As Vec2
    Get
      Return (_viewPort)
    End Get

    Set(value As Vec2)
      _viewPort = value
      _proj = Mat3.Translation(New Vec2(_viewPort.x * 0.5, _viewPort.y * 0.5))
      _invProj = _proj.Inversed()
    End Set
  End Property

  Public Function Transform() As Mat3
    Dim T = Mat3.Translation(Position)
    Dim S = Mat3.Scaling(New Vec2(Zoom, Zoom))

    Return (T * S)
  End Function

  Public Function Scaling() As Mat3
    Return (Mat3.Scaling(New Vec2(Zoom, Zoom)))
  End Function

  Public Function Projection() As Mat3
    Return (_proj)
  End Function

  Public Function TopLeft() As Vec2
    Return (Position - (Scaling() * ViewPort) * 0.5)
  End Function

  Public Function BottomRight() As Vec2
    Return (Position + (Scaling() * ViewPort) * 0.5)
  End Function

  ''' <summary>
  ''' Returns the world coordinates of the specified point in view coordinates.
  ''' </summary>
  ''' <param name="v">The view (ie control) coordinates.</param>
  ''' <returns></returns>
  Public Function ViewToWorld(v As Vec2) As Vec2
    Return (Transform() * _invProj * v)
  End Function

  Public Zoom As Single = 1.0
  Public Position As New Vec2()

  Private _proj As New Mat3()
  Private _invProj As New Mat3()
  Private _viewPort As New Vec2()
End Class
