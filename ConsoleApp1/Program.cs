using System;

class VigenereCipher
{
    //Функция для шифрования текста с использованием ключа
    static string EncryptV(string plainText, string key)
    {
        string encryptedText = "";
        int keyIndex = 0;
        foreach (char c in plainText)
        {
            // Индекс символа в алфавите (A=0, B=1, ..., Z=25)
            int plainCharIndex = c - 'A';
            // Если символ не является буквой, добавляем его без изменений
            if (plainCharIndex < 0 || plainCharIndex > 25)
            {
                encryptedText += c;
                continue;
            }

            // Индекс символа ключа в алфавите
            int keyCharIndex = key[keyIndex % key.Length] - 'A';

            // Шифрование символа
            int encryptedCharIndex = (plainCharIndex + keyCharIndex) % 26;

            // Преобразование индекса обратно в символ
            encryptedText += (char)(encryptedCharIndex + 'A');

            keyIndex++;
        }
        return encryptedText;
    }

    // Функция для дешифрования текста с использованием ключа
    static string DecryptV(string encryptedText, string key)
    {
        string decryptedText = "";
        int keyIndex = 0;
        foreach (char c in encryptedText)
        {
            // Индекс символа в алфавите (A=0, B=1, ..., Z=25)
            int encryptedCharIndex = c - 'A';
            // Если символ не является буквой, добавляем его без изменений
            if (encryptedCharIndex < 0 || encryptedCharIndex > 25)
            {
                decryptedText += c;
                continue;
            }

            // Индекс символа ключа в алфавите
            int keyCharIndex = key[keyIndex % key.Length] - 'A';

            // Дешифрование символа
            int decryptedCharIndex = (encryptedCharIndex - keyCharIndex + 26) % 26;

            // Преобразование индекса обратно в символ
            decryptedText += (char)(decryptedCharIndex + 'A');

            keyIndex++;
        }
        return decryptedText;
    }




    static void Main(string[] args)
    {
        Console.WriteLine("Enter the original text: ");
        string plainTextV = Console.ReadLine()!; // Исходный текст
        Console.WriteLine("Enter the key: ");
        string keyV = Console.ReadLine()!; // Ключ
        Console.WriteLine("Original text: " + plainTextV);

        // Шифрование текста
        string encryptedTextV = EncryptV(plainTextV.ToUpper(), keyV.ToUpper());
        Console.WriteLine("Encrypted text: " + encryptedTextV);

        // Дешифрование текста
        string decryptedTextV = DecryptV(encryptedTextV.ToUpper(), keyV.ToUpper());
        Console.WriteLine("Decrypted text: " + decryptedTextV);


    }
}
