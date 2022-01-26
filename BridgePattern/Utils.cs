using BridgePattern.Entities;

namespace BridgePattern;

public static class Utils
{
    public static string GetPrice(LicenseOld license)
    {
        return $"${license.GetPrice():0.00}";
    }
    
    public static string GetPrice(LicenseNew license)
    {
        return $"${license.GetPrice():0.00}";
    }

    public static string GetValidFor(LicenseOld license)
    {
        var expDate = license.GetExpirationDate();

        if (expDate == null)
        {
            return "forever";
        }

        var timeSpan = expDate.Value - DateTime.Now;

        return $"{timeSpan.Days}d {timeSpan.Hours}h {timeSpan.Minutes}m";
    }
    
    public static string GetValidFor(LicenseNew license)
    {
        var expDate = license.GetExpirationDate();

        if (expDate == null)
        {
            return "forever";
        }

        var timeSpan = expDate.Value - DateTime.Now;

        return $"{timeSpan.Days}d {timeSpan.Hours}h {timeSpan.Minutes}m";
    }
}