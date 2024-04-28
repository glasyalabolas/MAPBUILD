Imports System.Globalization

Public Module Utils
  Public Function Number(v As Single) As String
    Dim nf = CultureInfo.InvariantCulture.NumberFormat
    Return (v.ToString("0.00", nf))
  End Function
End Module
