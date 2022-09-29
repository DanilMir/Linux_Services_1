# Контрольная работа по сервисам Linux - 1
## Миргаязов Данил, 11-010
___
### Установка .NET Ubuntu 22.04

```
sudo apt-get update
sudo apt-get install -y dotnet6
```

Подробнее/установка на другие дистрибутивы Linux: https://learn.microsoft.com/ru-ru/dotnet/core/install/linux

### Запуск Сервер/Клиент

Скопировать репозиторий
```
git clone https://github.com/DanilMir/Linux_Services_1
```

Переход в директорию решения
```
cd Linux_Services_1
```

Запуск сервера
```
dotnet run --project ./timeserver/
```

Запуск клиента
```
dotnet run --project ./timeclient/
```
