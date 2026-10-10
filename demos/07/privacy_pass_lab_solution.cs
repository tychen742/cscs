using System;

static bool IsValidEmail(string email)
{
    int at = email.IndexOf('@');
    if (at < 1 || email.IndexOf('@', at + 1) != -1 || email.Contains(" "))
    {
        return false;
    }
    return email.IndexOf('.', at) != -1;
}

static string MaskEmail(string email)
{
    if (!IsValidEmail(email))
    {
        return "(invalid email)";
    }
    return email.Substring(0, 1) + "***" + email.Substring(email.IndexOf('@'));
}

static string MaskPhone(string phone)
{
    string digits = "";
    foreach (char c in phone)
    {
        if (char.IsDigit(c))
        {
            digits += c;
        }
    }
    if (digits.Length != 10)
    {
        return "(invalid phone)";
    }
    return "***-***-" + digits.Substring(6);
}

static string CheckAge(string ageInput)
{
    if (!int.TryParse(ageInput, out int age))
    {
        return "age must be a whole number";
    }
    if (age < 18 || age > 120)
    {
        return "age must be from 18 to 120";
    }
    return "ok";
}

static string SignupLogLine(string name, string email, string phone, string ageInput)
{
    if (!IsValidEmail(email))
    {
        return "REJECTED: invalid email";
    }
    string ageCheck = CheckAge(ageInput);
    if (ageCheck != "ok")
    {
        return "REJECTED: " + ageCheck;
    }
    return $"ACCEPTED: {MaskEmail(email)} {MaskPhone(phone)}";
}

Console.WriteLine(IsValidEmail("ana.diaz@example.com"));
Console.WriteLine(IsValidEmail("ana.diaz@example"));
Console.WriteLine(IsValidEmail("@example.com"));
Console.WriteLine(IsValidEmail("ana diaz@example.com"));
Console.WriteLine(IsValidEmail("ana@@example.com"));
Console.WriteLine(MaskEmail("ana.diaz@example.com"));
Console.WriteLine(MaskEmail("bo@example.com"));
Console.WriteLine(MaskEmail("not-an-email"));
Console.WriteLine(MaskPhone("(573) 555-0142"));
Console.WriteLine(MaskPhone("573.555.0199"));
Console.WriteLine(MaskPhone("555-0142"));
Console.WriteLine(CheckAge("34"));
Console.WriteLine(CheckAge("17"));
Console.WriteLine(CheckAge("abc"));
Console.WriteLine(CheckAge("250"));
Console.WriteLine(SignupLogLine("Ana Diaz", "ana.diaz@example.com", "(573) 555-0142", "34"));
Console.WriteLine(SignupLogLine("Bo Lee", "bo.lee@example", "573-555-0199", "29"));
Console.WriteLine(SignupLogLine("Cy Park", "cy@example.com", "573 555 0110", "16"));
