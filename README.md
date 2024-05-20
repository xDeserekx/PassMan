<p align="center">
  <img src="https://github.com/xDeserekx/PassMan/blob/master/PassMan/Images/image.ico" width=150>
</p>

# PassMan

Simple offline password manager for Windows in C# WPF.

![alt text](https://github.com/xDeserekx/PassMan/blob/master/PassMan/Images/1.png)

# Features

 - Create/Delete vaults
 - Import/Export vaults
 - Shared vaults
 - Change Master Password for vaults
 - Add/delete account for applications in vault
 - Update application account passwords
 - Exit logged vault on entering lock screen event or suspend.
 - Generate strong passwords.
 - Show password temporary when entered on password boxes. Right click on 'Show' button.
 - Copy password from applications to clipboard for a duration of 15 seconds.
   (If in the 15 seconds interval is copied something else on clipboard, PassMan will not clear the clipboard whe time expired or app is closed) 
 - After log in vault, master password required window will be prompted every 30 minutes if a action is made. Example: update password, delete account , etc.
 - Open vault session expires after a certain time if no action is made on it. Default: after 10 minutes.

# How it works

  Vaults:
  - Creating a vault: press on '+' sign down bellow and you will be prompted for vault name and master password. Every vault is created in Windows user profile.
  - Delete a vault: select the vault that you want to delete or remove(for shared vaults only) from list and press on '-' sign down bellow or right click on vault and choose 'Delete vault'. INFO: shared vaults files wont be deleted only removed from displaying on vault list.
  - Import vault: press on 'I' letter down bellow and a message box will appear to choose if you want to import locally the vault or shared(Ex.: using a vault file on a file server). After a file dialog will be opened for selecting the vault file. The file extension must end in '.x' .
  - Export vault: right click on the vault name from list that you want to export and choose 'Export vault'. You will be prompted with a file save dialog.
  - Change Master Password: right click on the vault name from list that you want to change the password and choose 'Change Master Password'.
 
  Applications:
  - Add application: press on '+' sign down bellow and you will be prompted with a window for adding application name, account name and password.
  - Delete account: select the account from specific application that you want to delete and press on '-' sign down bellow or right click on application/account and choose 'Delete Account'
  - Update account password: right click on account and choose update 'Update account password'. You will be prompted with a pop window to enter new password for account.
  - Show password: right click on account and choose update 'Show password'. Password will be visible on application list.
  - Copy to Clipboard: right click on account and choose update 'Copy to clipboard (15 seconds available)'. Password will be copied on clipboard for 15 seconds.

  Settings:
  - You can set the vault session expiration time. The default value is set on 10 minutes.


# Encryption

For password hash is used Argon2 (argon2id) https://en.wikipedia.org/wiki/Argon2. And for encryption is used Rijndael AES-256.
The Passwowrd Manager generates a vault file for every user logged in system. You cannot see the vaults from other user on that machine.

## Requirements:

.NET 8

## Samples


![alt text](https://github.com/xDeserekx/PassMan/blob/master/PassMan/Images/2.png)


![alt text](https://github.com/xDeserekx/PassMan/blob/master/PassMan/Images/3.png)
