Public Class CreateLinesCommand
  Implements ICommand

  Public Sub New()

  End Sub

  Public Sub Execute() Implements ICommand.Execute
    Throw New NotImplementedException()
  End Sub

  Public Sub Undo() Implements ICommand.Undo
    Throw New NotImplementedException()
  End Sub

  Public Sub Redo() Implements ICommand.Redo
    Throw New NotImplementedException()
  End Sub
End Class
