# TransactionAPI Documentation

- [TransactionAPI](#transactionapi-documentation)
    - [Create Transaction](#create-transaction)
        - [Create Transaction Request](#create-transaction-request)
        - [Create Transaction Response](#create-transaction-response)
    -  [Get Transaction](#get-transaction)
        - [Get Transaction Request](#get-transaction-request)
        - [Get Transaction Response](#get-transaction-response)

## Create Transaction

### Create Transaction -- Request

```js
POST {{host}}/transactions
```

```json
{
    "amount": 101.78,
    "customer": "Alot Media",
    "device": "ONUC-0009"
}
```

### Create Transaction -- Response

```js
201 Created
```

```yml
Location: {{host}}/transactions/{{id}}
```

```json
{
    "orderID": "97e0c4af-a609-41bd-94bd-288d135ffcd0",
    "placed": "2023-10-26T08:00:00",
    "total": 101.78,
    "status": "pending",
    "customer": "Alot Media",
    "device": "ONUC-0009",
    "lastModified": "2023-10-26T08:00:00"
}
```

## Get Transaction

### Get Transaction -- Request

```js
GET /transactions/{{id}}
```

### Get Transaction -- Response

```js
200 Ok
```

```json
{
   "orderID": "97e0c4af-a609-41bd-94bd-288d135ffcd0",
    "placed": "2023-10-26T08:00:00",
    "total": 101.78,
    "status": "pending",
    "customer": "Alot Media",
    "device": "ONUC-0009",
    "lastModified": "2023-10-26T08:00:00"
}
```