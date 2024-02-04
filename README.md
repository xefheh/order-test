# 1. Таблица адресов (Docker):
     
|Address | Name|
|--|--|
|http://localhost:8080|ASP.NET APPLICATION|
|http://localhost:8081|SEQ|
|http://localhost:5432|POSTGRES|

# 2. Swagger:
Адрес - http://localhost:8080/swagger

# 3. Endpoints:
## 3.1. Товары
### 3.1.1. Получение списка товаров
<b>Endpoint:</b> address/api/Product [GET METHOD]
<b>Ответ:</b>
```json
{
  "productDetails": [
    {
      "id": "OID товара (GUID)",
      "name": "Имя товара",
      "price": "Цена товара"
    }
  ]
}
```
### 3.1.2. Добавление товара
<b>Endpoint:</b> address/api/Product [POST METHOD]
<b>Запрос:</b>
```json
{
  "name": "Имя товара",
  "price": "Цена товара"
}
```
<b>Ответ:</b> OID товара (GUID)
### 3.1.3. Удаление товара
<b>Endpoint:</b> address/api/Product/{id} [DELETE METHOD]
## 3.2. Заказы:
### 3.2.1. Получение списка заказов по OID пользователя.
<b>Endpoint:</b> address/api/Order/{userId} [GET METHOD]
<b>Ответ:</b>
```json
{
  "orderDetails": [
    {
      "id": "OID заказа",
      "userId": "OID пользователя",
      "creationDate": "Дата создания заказа",
      "productPositions": [
        {
          "price": "цена товара",
          "count": "количество товара",
          "productId": "oid товара"
        }
      ]
    }
  ]
}
```
### 3.2.2. Создание заказа.
<b>Endpoint:</b> address/api/Order [POST METHOD]
<b>Запрос:</b>
```json
{
  "userId": "OID пользователя",
  "addOrderPairs": [
    {
      "productId": "OID товара",
      "count": "количество"
    }
  ]
}
```
<b>Ответ:</b> OID заказа (GUID)
### 3.2.2. Отмена заказа.
<b>Endpoint:</b> address/api/Order [DELETE METHOD]

<b>Query:</b>
- OID заказа
- OID пользователя
