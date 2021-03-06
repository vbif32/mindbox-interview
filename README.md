# Задача 1
> Вы собираетесь совершить долгое путешествие через множество населенных пунктов. Чтобы не запутаться, вы сделали карточки вашего путешествия. Каждая карточка содержит в себе пункт отправления и пункт назначения. 
>
Гарантируется, что если упорядочить эти карточки так, чтобы для каждой карточки в упорядоченном списке пункт назначения на ней совпадал с пунктом отправления в следующей карточке в списке, получится один список карточек без циклов и пропусков. 
Например, у нас есть карточки 
* Мельбурн > Кельн 
* Москва > Париж 
* Кельн > Москва
>
Если упорядочить их в соответствии с требованиями выше, то получится следующий список: 
Мельбурн > Кельн, Кельн > Москва, Москва > Париж 
>
Требуется: 
>
Написать функцию, которая принимает набор неупорядоченных карточек и возвращает набор упорядоченных карточек в соответствии с требованиями выше, то есть в возвращаемом из функции списке карточек для каждой карточки пункт назначения на ней должен совпадать с пунктом отправления на следующей карточке.
* Дать оценку сложности получившегося алгоритма сортировки 
* Написать тесты 

1. Сложность полученного алгоритма сортировки O(N^2). Думаю, что можно снизить сложность, но "с ходу" не нашел.
2. [Ссылка на код] (https://github.com/vbif32/mindbox-interview/blob/master/Task1/Task1.cs)


# Задача 2
> Есть таблица хранящая покупки (линии чека): Sales: salesid, productid, datetime, customerid. Мы хотим понять, через какие продукты клиенты «попадают» к нам в магазин. Напишите запрос, который выводит продукт и количество случаев, когда он был первой покупкой клиента.

* [Ссылка на код] (https://github.com/vbif32/mindbox-interview/blob/master/Task2/Task2.sql)
