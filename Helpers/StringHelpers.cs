namespace ProductTask.Helpers;

public static class StringHelpers
{
    public static bool IsPhoneNumberValid(string phoneNumber) => phoneNumber.Length == 13 && phoneNumber.StartsWith("+992");
    
    public static bool IsEmailValid(string email) => email.Contains("@") && email.Contains(".");
}