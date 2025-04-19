Отчёт по проекту ZooManagerWebApp
Реализованный функционал
Основные сценарии работы и их реализация
Управление животными

Добавление новых животных: реализовано через AnimalController.AddAnimal() и AnimalTransferService.AddAnimal()

Удаление животных: выполнено в AnimalController.RemoveAnimal() и AnimalTransferService.RemoveAnimal()

Работа с вольерами

Создание вольеров: обработка в EnclosureController.AddEnclosure()

Удаление вольеров: функционал в EnclosureController.RemoveEnclosure()

Операции перемещения

Перемещение животных между вольерами: реализовано в AnimalController.TransferAnimal() и AnimalTransferService.TransferAnimal()

Расписание кормления

Просмотр графика кормлений: ZooStatisticsController.GetFeedingScheduleStatistics() и ZooStatisticsService.GetFeedingScheduleStatistics()

Добавление новых кормлений: FeedingOrganizationService.AddFeedingSchedule()

Статистические данные

Общее количество животных: ZooStatisticsController.GetTotalAnimals() + ZooStatisticsService.GetAmountOfAnimals()

Количество вольеров: ZooStatisticsController.GetTotalEnclosures() + ZooStatisticsService.GetAmountOfEnclosures()

Свободные вольеры: ZooStatisticsController.GetFreeEnclosures() + ZooStatisticsService.GetFreeEnclosureStatistics()

Применённые архитектурные подходы
Domain-Driven Design (DDD)
Ключевые сущности

Основные доменные объекты: Animal, Enclosure, FeedingSchedule с уникальными идентификаторами и собственной бизнес-логикой

Расположение: пространство имён ZooManagerWebApp.Domain.Entities

Объекты-значения

Используются для описания неизменяемых характеристик:

Для животных: AnimalType, AnimalName, AnimalBirthday, AnimalFavoriteFood

Для вольеров: EnclosureType, EnclosureSize, EnclosureCapacity

Для кормлений: FoodType, FeedingTime

Расположение: ZooManagerWebApp.Domain.ValueObjects

Интерфейсы хранилищ

Абстракции для работы с данными: IAnimalStorage, IEnclosureStorage, IFeedingScheduleStorage

Определены в ZooManagerWebApp.Domain.Interfaces

Доменные сервисы

Содержат комплексную бизнес-логику:

AnimalTransferService - операции с животными

ZooStatisticsService - работа со статистикой

FeedingOrganizationService - управление кормлениями

Clean Architecture
Слоистая структура

Домен: ядро системы с бизнес-правилами (сущности, value objects)

Приложение: реализация use cases (сервисы)

Представление: обработка запросов (контроллеры)

Ключевые принципы

Инверсия зависимостей: сервисы работают с абстракциями хранилищ

Тестируемость: DI позволяет легко подменять реализации для тестов

Единая ответственность: каждый компонент решает строго определённую задачу

Итоги реализации
Проект успешно реализует все запланированные функции управления зоопарком, следуя современным архитектурным практикам. Применение DDD позволило точно отразить предметную область, а Clean Architecture обеспечила чёткое разделение ответственности между компонентами. Система обладает хорошей тестируемостью и поддерживаемостью благодаря продуманной слоистой структуре.
