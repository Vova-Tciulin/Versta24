# Тестовое задание для Versta24

##Запуск проекта

1. <a href="https://dotnet.microsoft.com/en-us/download">Скачать и установить .Net Core SDK 8</a>
2.  Если на вашей системе нет localdb, то <a href="https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16">скачать и установить SQL Server Express</a>
3. склонировать проект, используя команду:
```powershell
git clone https://github.com/Vova-Tciulin/Versta24.git
```
4. открыть в терминале в корневую папку Versta24/ и ввести команды для запуска сервиса: 
```powershell
dotnet build
dotnet run --project ./src/server/Versta24.Api
```
- BackEnd будет доступен по ссылке: https://localhost:7219/swagger

5. для запуска клиента открыть терминал в директорию ./src/client/versta24.client

- Ввести команды в консоли: 
```powershell
npm install
npm run dev
```
- Клиент будет доступен по ссылке: https://localhost:5173/
