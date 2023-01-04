CREATE MASTER KEY ENCRYPTION BY   
PASSWORD = 'ZwzXaeMixus8ib7Mvuth'; 

GO

CREATE CERTIFICATE AltFuturePWD  
   WITH SUBJECT = 'AltFuture User Passwords';  
GO  

CREATE SYMMETRIC KEY PWD_Key_01  
    WITH ALGORITHM = AES_256  
    ENCRYPTION BY CERTIFICATE AltFuturePWD;  
GO  

USE Altfuture;  
GO  



-- Create a column in which to store the encrypted data.  
ALTER TABLE dbo.Users 
    ADD password_encrypted varbinary(128);   
GO  

-- Open the symmetric key with which to encrypt the data.  
OPEN SYMMETRIC KEY PWD_Key_01  
   DECRYPTION BY CERTIFICATE AltFuturePWD;  

-- Encrypt the value in column NationalIDNumber with symmetric   
-- key SSN_Key_01. Save the result in column EncryptedNationalIDNumber.  
UPDATE dbo.Users  
SET password_encrypted = EncryptByKey(Key_GUID('PWD_Key_01'), [password]);  
GO  

close symmetric key PWD_key_01

-- Verify the encryption.  
-- First, open the symmetric key with which to decrypt the data.  
OPEN SYMMETRIC KEY PWD_Key_01  
   DECRYPTION BY CERTIFICATE AltFuturePWD;  
GO  

-- Now list the original ID, the encrypted ID, and the   
-- decrypted ciphertext. If the decryption worked, the original  
-- and the decrypted ID will match.  
SELECT [password], password_encrypted   
    ,  
    CONVERT(varchar, DecryptByKey(password_encrypted))   
    AS password_unencrypted  
    FROM dbo.Users;
GO  

close symmetric key PWD_Key_01