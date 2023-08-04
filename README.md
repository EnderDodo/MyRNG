# Генератор псевдослучайных чисел на основе побайтовой ЛРП

Реализован простейший генератор псевдослучайных байтов

```C#
// создание генератора из двух массивов байтов
var coefficients = new byte[] { 22, 48, 19, 76 };
var values = new byte[] { 13, 64, 98 };
var myRandom1 = new MyRandom(coefficients, values); // n = 0
var myRandom2 = new MyRandom(coefficients, values, 4); // n = 4

// получение следующего псевдослучайного байта
var randomByte1 = myRandom1.Next();
var randomByte2 = myRandom2.Next();
```