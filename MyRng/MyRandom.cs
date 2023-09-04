using FiniteFieldsLib;

namespace MyRng;

public class MyRandom
{
    private static BinaryFiniteField _field = new BinaryFiniteField(8, new[] { 1, 0, 0, 0, 1, 1, 1, 0, 1 });
    private byte[] Coefficients { get; }
    private byte[] _values;

    public MyRandom(byte[] coefficients, byte[] values)
    {
        int lengthDifference = coefficients.Length - values.Length;
        switch (lengthDifference - 1)
        {
            case > 0:
                values = values.Concat(new byte[lengthDifference]).ToArray();
                break;
            case < 0:
                coefficients = coefficients.Concat(new byte[-lengthDifference]).ToArray();
                break;
        }

        Coefficients = new byte[coefficients.Length];
        coefficients.CopyTo(Coefficients, 0);

        _values = new byte[values.Length];
        values.CopyTo(_values, 0);
    }

    public byte Next()
    {
        var freeTermByte = Coefficients[^1];
        var result = _field.GetElementFromBytes(freeTermByte);

        for (int i = 0; i < Coefficients.Length - 1; i++)
        {
            result += _field.GetElementFromBytes(Coefficients[i]) * _field.GetElementFromBytes(_values[i]);
        }

        for (int i = 0; i < _values.Length - 1; i++)
        {
            _values[i] = _values[i + 1];
        }

        _values[^1] = _field.GetBytesFromElement(result)[0];
        //_values[Coefficients.Length - 1 + n] = result;
        return _values[^1];
    }
}