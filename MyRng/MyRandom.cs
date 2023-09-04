using FiniteFieldsLib;

namespace MyRng;

public class MyRandom
{
    private static BinaryFiniteField _field = new BinaryFiniteField(8, new[] { 1, 0, 0, 0, 1, 1, 1, 0, 1 });

    private byte[] Coefficients { get; }
    private byte[] _values;
    private int Enumerator { get; }

    public MyRandom(byte[] coefficients, byte[] values, int n)
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
        for (int i = 0; i < coefficients.Length; i++)
        {
            Coefficients[i] = coefficients[i];
        }

        _values = new byte[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            _values[i] = values[i];
        }

        Enumerator = n;
    }

    public MyRandom(byte[] coefficients, byte[] values) : this(coefficients, values, 0)
    {
    }

    public byte Next()
    {
        return GetRandomByte(Enumerator);
    }

    private byte GetRandomByte(int n)
    {
        var freeTermByte = Coefficients[^1];
        var result = _field.GetElementFromBytes(freeTermByte);


        for (int n1 = 0; n1 <= n; n1++)
        {
            for (int i = 0; i < Coefficients.Length - 1; i++)
            {
                result += _field.GetElementFromBytes(Coefficients[i]) * _field.GetElementFromBytes(_values[i]);
            }

            for (int i = 0; i < _values.Length - 1; i++)
            {
                _values[i] = _values[i + 1];
            }

            _values[^1] = _field.GetBytesFromElement(result)[0];
            result = _field.GetElementFromBytes(freeTermByte);
        }

        //_values[Coefficients.Length - 1 + n] = result;
        return _values[^1];
    }
}