# VkPostParserApi

## Решение тестового задания U Summer School 2023, направление .net
Написать web-приложение, которое обращается к личной странице в соц. сети «ВКонтакте», получает оттуда 5 последних постов, считает в этих постах вхождение одинаковых букв (сравнение регистро-независимое) 

Результат отсортировать по алфавиту, итоговые результаты подсчета записываются в БД ( PostgresSQL). 

Информация о запуске подсчета и об его окончание должна записываться в лог файл на локальной файловой системе. 

В качестве UI для взаимодействия с backend частью использовать Swagger

## Для запуска необходимо:
- Вставить в ```appsetings.json``` в секцию ```ConnectionString:DefaultConnection``` строку подключения к PostgreSQL
- Добавить в секцию ```VkPostsApi:AccessToken``` ключ доступа пользователя
