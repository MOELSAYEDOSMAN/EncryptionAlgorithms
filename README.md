# Lib_SC: Encryption and Decryption Library

Lib_SC is a C# library that provides implementations for various encryption and decryption techniques. The library includes classes for Caesar, Monoalphabetic, Playfair, and Polyalphabetic ciphers. Each class offers methods to encrypt and decrypt strings using the respective cipher technique.

---

## Table of Contents

- [Features](#features)
- [Classes and Methods](#classes-and-methods)
  - [Caesar Cipher](#caesar-cipher)
  - [Monoalphabetic Cipher](#monoalphabetic-cipher)
  - [Playfair Cipher](#playfair-cipher)
  - [Polyalphabetic Cipher](#polyalphabetic-cipher)

---

## Features

- **Caesar Cipher**: Simple shift cipher where each letter in the plaintext is shifted a certain number of places down the alphabet.
- **Monoalphabetic Cipher**: Substitution cipher where each letter in the plaintext is replaced by a letter with a fixed relationship.
- **Playfair Cipher**: Digraph substitution cipher where plaintext letters are replaced using a 5x5 matrix.
- **Polyalphabetic Cipher**: Utilizes multiple Caesar ciphers in sequence with different shifts for each character based on its position.

---

## Classes and Methods

### Caesar Cipher

```csharp
namespace Lib_SC
{
    public class Caesar
    {
        /// <summary>
        /// Encrypts or decrypts a given string using a specified key.
        /// </summary>
        /// <param name="encryption">The string to encrypt or decrypt.</param>
        /// <param name="key">The encryption or decryption key.</param>
        /// <param name="enc">True for encryption, False for decryption.</param>
        /// <returns>The encrypted or decrypted string.</returns>
        public static string MainCaesar(string encryption, int key, bool enc);
    }
}
 ```
###Monoalphabetic Cipher
```csharp
namespace Lib_SC
{
    public class Monoalphabetic
    {
        /// <summary>
        /// Encrypts or decrypts a given string using a specified key.
        /// </summary>
        /// <param name="oldText">The string to encrypt or decrypt.</param>
        /// <param name="key">The encryption or decryption key.</param>
        /// <param name="encrypt">True for encryption, False for decryption.</param>
        /// <returns>The encrypted or decrypted string.</returns>
        public static string MainFunctionMonoalphabetic(string oldText, string key, bool encrypt);
    }
}
 ```

###Playfair Cipher
```csharp
namespace Lib_SC
{
    public class Playfair
    {
        /// <summary>
        /// Encrypts or decrypts a given string using a specified key and Playfair cipher logic.
        /// </summary>
        /// <param name="text">The string to encrypt or decrypt.</param>
        /// <param name="key">The encryption or decryption key.</param>
        /// <param name="encryptionBool">True for encryption, False for decryption.</param>
        /// <returns>The encrypted or decrypted string.</returns>
        public static string MainPlayfair(string text, string key, bool encryptionBool);
    }
}

 ```

###Polyalphabetic Cipherr
```csharp
namespace Lib_SC
{
    public class Polyalphabetic
    {
        /// <summary>
        /// Encrypts or decrypts a given string using a polyalphabetic cipher.
        /// </summary>
        /// <param name="text">The string to encrypt or decrypt.</param>
        /// <param name="encrypt">True for encryption, False for decryption.</param>
        /// <returns>The encrypted or decrypted string.</returns>
        public static string MainPolyalphabetic(string text, bool encrypt);
    }
}

 ```

###PUsage
```csharp
using Lib_SC;
using System;

class Program
{
    static void Main()
    {
        string plaintext = "HELLO";
        bool encrypt = true;

        // Encrypt using Polyalphabetic cipher
        string encryptedText = Polyalphabetic.MainPolyalphabetic(plaintext, encrypt);
        Console.WriteLine($"Encrypted Text: {encryptedText}");

        // Decrypt using Polyalphabetic cipher
        encrypt = false;
        string decryptedText = Polyalphabetic.MainPolyalphabetic(encryptedText, encrypt);
        Console.WriteLine($"Decrypted Text: {decryptedText}");
    }
}


 ```
