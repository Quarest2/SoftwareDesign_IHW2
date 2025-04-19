Отчёт о проекте: ZooManager

Реализованная функциональность

Use Cases и соответствующие классы/модули
1) Добавление / удаление животного
- Добавить животное: реализовано в AnimalController (метод AddAnimal) и в AnimalTransferService (метод AddAnimal). 
- Удалить животное: реализовано в AnimalController (метод RemoveAnimal) и в AnimalTransferService (метод RemoveAnimal). 
2) Добавление / удаление вольера
- Добавить вольер: реализовано в EnclosureController (метод AddEnclosure).
- Удалить вольер: реализовано в EnclosureController (метод RemoveEnclosure).
3) Перемещение животного между вольерами
- Реализовано в AnimalController (метод TransferAnimal) и в AnimalTransferService (метод TransferAnimal).
4) Просмотр расписания кормления
- Реализовано в ZooStatisticsController (метод GetFeedingScheduleStatistics) и в ZooStatisticsService (метод GetFeedingScheduleStatistics).
5) Добавление нового кормления в расписание
- Реализовано в FeedingOrganizationService (метод AddFeedingSchedule).
6) Просмотр статистики зоопарка
- Всего животных: реализовано в ZooStatisticsController (метод GetTotalAnimals) и в ZooStatisticsService (метод GetAmountOfAnimals).
- Всего вольеров: реализовано в ZooStatisticsController (метод GetTotalEnclosures) и в ZooStatisticsService (метод GetAmountOfEnclosures).
- Свободные вольеры: реализовано в ZooStatisticsController (метод GetFreeEnclosures) и в ZooStatisticsService (метод GetFreeEnclosureStatistics).


Концепции Domain-Driven Design (DDD) и принципы Clean Architecture

Концепции DDD
1) Сущности (Entities)
- Animal, Enclosure и FeedingSchedule реализованы как сущности с уникальными идентификаторами и инкапсулированным поведением.
- Пример: Animal в ZooManagerWebApp.Domain.Entities.
2) Объекты-значения (Value Objects)
- Используются для представления неизменяемых и описательных доменных концепций.
- Примеры:
- - AnimalType, AnimalName, AnimalBirthday, AnimalFavoriteFood в ZooManagerWebApp.Domain.ValueObjects.AnimalValueObjects.
- - EnclosureType, EnclosureSize, EnclosureCapacity в ZooManagerWebApp.Domain.ValueObjects.EnclosureValueObjects.
- - FoodType, FeedingTime в ZooManagerWebApp.Domain.ValueObjects.FeedingScheduleValueObjects.
3) Репозитории (интерфейсы хранилищ)

- Интерфейсы, такие как IAnimalStorage, IEnclosureStorage и IFeedingScheduleStorage, абстрагируют слой хранения данных.
- Пример: определены в ZooManagerWebApp.Domain.Interfaces.
4) Доменные сервисы
- Бизнес-логика, охватывающая несколько сущностей, инкапсулируется в сервисах.
- Примеры:
- - AnimalTransferService обрабатывает операции, связанные с животными.
- - ZooStatisticsService предоставляет статистику по зоопарку.
- - FeedingOrganizationService управляет расписаниями кормления.


Принципы Clean Architecture
1) Разделение ответственности
- Проект разделён на слои:
- - Доменный слой (Domain Layer): содержит бизнес-логику (сущности, value object’ы и интерфейсы).
- - Слой приложения (Application Layer): содержит реализации use case’ов (AnimalTransferService, ZooStatisticsService).
- - Слой представления (Presentation Layer): контроллеры, обрабатывающие HTTP-запросы (AnimalController, ZooStatisticsController).
2) Инверсия зависимостей (Dependency Inversion)
- Модули верхнего уровня (например, сервисы) зависят от абстракций (например, IAnimalStorage), а не от конкретных реализаций.
3) Тестируемость
- Использование внедрения зависимостей и мокабельных интерфейсов (например, Mock<IAnimalStorage>) делает приложение легко тестируемым.
4) Принцип единой ответственности
- Каждый класс выполняет только одну задачу:
- - AnimalController — обработка HTTP-запросов, связанных с животными.
- - AnimalTransferService — бизнес-логика, связанная с животными.
- - ZooStatisticsService — предоставление статистики.


Итог

Проект следует принципам Domain-Driven Design, моделируя предметную область с помощью сущностей, объектов-значений и доменных сервисов. Принципы Clean Architecture обеспечивают разделение ответственности, тестируемость и поддерживаемость. Вся требуемая функциональность реализована в слоях Presentation, Application и Domain с чёткими границами и обязанностями.