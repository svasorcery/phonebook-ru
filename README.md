# phonebook-ru
Service that gets operator's and region's info by phone number.

Usage:

```C#
var phonebook = new Services.PhonebookService();
var phoneInfo = phonebook.GetInfo("9157048808");
```

or:

```C#
var _phones = new List<string>
{
    "7 895 6551 // номер-инвалид",
    "9965547892",
    "+7 (916) 987-65-43",
    "8-904-123-45-67",
    "(930) 1357901",
    "тел: 7(915)7002134 доб 112 (Мария)",
    "979 555 55 55 // номер валидный, но такого префикса нет",
    "8-997-8583465 // префикс есть, но не все номера заняты",
    "8902 201 1111 11 // существует, но регион - вся Россия (id=0)",
    "8119898988",
};
            
var phonebook = new Services.PhonebookService();
var phonesInfoList = phonebook.GetInfo(_phones);
```
