# SwimRankings
# Моя попытка создать что-то похожее на <https://www.swimrankings.net/> , на этом сайте можно найти любого спортсмена(пловца) и просмотреть его имеющиеся результаты(где-то там есть даже я)
# В этом проекте я попробовал сделать очень укороченную версию с четырьмя таблицами : Countries, Swimmers, Distances и  Results
# У каждого объекта класса Result есть DistanceId, указывающий на объект класса Distance и SwimmerId, указыыающий на объект класса Swimmer показавшего результат на этой дистанции
# У каждого пловца ессть Id страны к которой он принадлежит
# В классе Country я хотел реализовать свойство List<Swimmer> Swmimmers, чтобы по Id страны можно было просмотреть всех пловцов принадлежащих к конкретной стране, но что-то не до конца получилось(то же самое я пытался в классе Swimmer, только чтобы у каждого пловца был лист результатов)
