namespace ChainPattern.Validators;

public class BarCodeValidator
{
    public bool Validate(string? barcode)
    {
        if (barcode == null) return false;
        return barcode.Length == 10;
    }
}