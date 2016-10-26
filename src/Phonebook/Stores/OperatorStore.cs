using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Stores
{
    public class OperatorStore
    {
        private List<Operator> _operators;

        public OperatorStore()
        {
            InitStore();
        }


        public List<Operator> All()
        {
            return _operators;
        }

        public Operator Find(int id)
        {
            try
            {
                return _operators.First(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new ArgumentNullException($"Запись с id={id} не найдена", e);
            }
        }

        public Operator[] Search(string name)
        {
            return _operators.Where(x => 
                    x.Name.ToLower().Contains(name.Trim().ToLower())
                    || x.ShortName.ToLower().Contains(name.Trim().ToLower())
                ).ToArray();
        }

        private void InitStore()
        {
            _operators = new List<Operator>
            {
                new Operator { Id = 0,  ShortName = "", Name = "Стационарный телефон" },
                new Operator { Id = 1,  ShortName = "Ростелеком", Name = "ОАО \"Ростелеком\"" },
                new Operator { Id = 2,  ShortName = "Ростелеком", Name = "ПАО \"Ростелеком\"" },
                new Operator { Id = 3,  ShortName = "МТС", Name = "ОАО \"Мобильные ТелеСистемы\"" },
                new Operator { Id = 4,  ShortName = "МТС", Name = "ПАО \"Мобильные ТелеСистемы\"" },
                new Operator { Id = 5,  ShortName = "Билайн", Name = "ОАО \"Вымпел-Коммуникации\"" },
                new Operator { Id = 6,  ShortName = "Билайн", Name = "ПАО \"Вымпел-Коммуникации\"" },
                new Operator { Id = 7,  ShortName = "МегаФон", Name = "ОАО \"МегаФон\"" },
                new Operator { Id = 8,  ShortName = "МегаФон", Name = "ПАО \"МегаФон\"" },
                new Operator { Id = 9,  ShortName = "Теле2", Name = "ООО \"Т2 Мобайл\"" },
                new Operator { Id = 10, ShortName = "Теле2", Name = "ОАО \"Теле2-Санкт-Петербург\"" },
                new Operator { Id = 11, ShortName = "Теле2", Name = "ЗАО \"РТ-Мобайл\"" },
                new Operator { Id = 12, ShortName = "Yota", Name = "ООО \"Скартел\"" },
                new Operator { Id = 13, ShortName = "СМАРТС", Name = "СМАРТС" },
                new Operator { Id = 14, ShortName = "СМАРТС", Name = "АО \"СМАРТС-Саранск\"" },
                new Operator { Id = 15, ShortName = "СМАРТС", Name = "Акционерное общество \"СМАРТС-Ульяновск\"" },
                new Operator { Id = 16, ShortName = "СМАРТС", Name = "АО \"СМАРТС-Йошкар-Ола\"" },
                new Operator { Id = 17, ShortName = "СМАРТС", Name = "АО \"СМАРТС-Пенза\"" },
                new Operator { Id = 18, ShortName = "СМАРТС", Name = "АО \"СМАРТС-Астрахань\"" },
                new Operator { Id = 19, ShortName = "СМАРТС", Name = "Акционерное общество \"СМАРТС-Саратов\"" },

                new Operator { Id = 20, ShortName = "", Name = "ОАО \"АСВТ\"" },
                new Operator { Id = 21, ShortName = "", Name = "ООО \"Глобал Телеком\"" },
                new Operator { Id = 22, ShortName = "", Name = "Акционерное общество \"ГЛОНАСС\"" },
                new Operator { Id = 23, ShortName = "", Name = "ООО \"Транснефть Телеком\"" },
                new Operator { Id = 24, ShortName = "", Name = "ОАО \"Межрегиональный ТранзитТелеком\"" },
                new Operator { Id = 25, ShortName = "", Name = "ООО \"Газпром телеком\"" },
                new Operator { Id = 26, ShortName = "", Name = "ООО \"ЕКАТЕРИНБУРГ-2000\"" },
                new Operator { Id = 27, ShortName = "", Name = "АО \"Мобиком Волга\"" },
                new Operator { Id = 28, ShortName = "", Name = "ЗАО \"Компания ТрансТелеКом\"" },
                new Operator { Id = 29, ShortName = "", Name = "ООО \"Эквант\"" },
                new Operator { Id = 30, ShortName = "", Name = "ЗАО \"РусСДО\"" },
                new Operator { Id = 31, ShortName = "", Name = "ОАО \"Основа Телеком\"" },
                new Operator { Id = 32, ShortName = "", Name = "ООО \"Твои мобильные технологии\"" },
                new Operator { Id = 33, ShortName = "", Name = "ОАО \"Московская городская телефонная сеть\"" },
                new Operator { Id = 34, ShortName = "", Name = "ЗАО \"Тюменьруском\"" },
                new Operator { Id = 35, ShortName = "", Name = "ООО \"Интернод\"" },
                new Operator { Id = 36, ShortName = "", Name = "ОАО \"Сотовая связь Башкортостана\"" },
                new Operator { Id = 37, ShortName = "", Name = "ООО \"Интеграл\"" },
                new Operator { Id = 38, ShortName = "", Name = "ООО \"СИМ ТЕЛЕКОМ\"" },
                new Operator { Id = 39, ShortName = "", Name = "ЗАО \"АКОС\"" },
                new Operator { Id = 40, ShortName = "", Name = "АО \"Глобалстар-Космические Телекоммуникации\"" },
                new Operator { Id = 41, ShortName = "", Name = "Кузбаск.сот. связь" },
                new Operator { Id = 42, ShortName = "", Name = "ТМ \"САТ\"" },
                new Operator { Id = 43, ShortName = "", Name = "ООО \"Спринт\"" },
                new Operator { Id = 44, ShortName = "", Name = "ООО \"Нэт Бай Нэт Холдинг\"" },
                new Operator { Id = 45, ShortName = "", Name = "государственное унитарное предприятие Севастополя \"СЕВАСТОПОЛЬ ТЕЛЕКОМ\"" },
                new Operator { Id = 46, ShortName = "", Name = "ООО \"Антарес\"" },
                new Operator { Id = 47, ShortName = "", Name = "ЗАО \"Мобильная сот.связь\"" },
                new Operator { Id = 48, ShortName = "", Name = "ОАО \"АПЕКС\"" },
                new Operator { Id = 49, ShortName = "", Name = "ЗАО \"СИБИНТЕРТЕЛЕКОМ\"" },
                new Operator { Id = 50, ShortName = "", Name = "ЗАО \"Ярославль-GSM\"" },
                new Operator { Id = 51, ShortName = "", Name = "ООО \"Иридиум Коммьюникешенс\"" },
                new Operator { Id = 52, ShortName = "", Name = "ООО \"ФЕБО Телеком\"" },
                new Operator { Id = 53, ShortName = "", Name = "ООО \"МАТРИКС телеком\"" },
                new Operator { Id = 54, ShortName = "", Name = "ООО \"Сонет\"" },
                new Operator { Id = 55, ShortName = "", Name = "ООО \"КТК ТЕЛЕКОМ\"" },
                new Operator { Id = 56, ShortName = "", Name = "ООО \"Арктур\"" },
                new Operator { Id = 57, ShortName = "", Name = "ОАО \"Арктик Регион Связь\"" },
                new Operator { Id = 58, ShortName = "", Name = "МТТ Инвест" },
                new Operator { Id = 59, ShortName = "", Name = "ОАО \"Региональный технический центр\"" },
                new Operator { Id = 60, ShortName = "", Name = "ЗАО \"Сотел- сот. связь Чувашии\"" },
                new Operator { Id = 61, ShortName = "", Name = "ОАО \"Облком\"" },
                new Operator { Id = 62, ShortName = "", Name = "Дагест сот связь" },
                new Operator { Id = 63, ShortName = "", Name = "ЗАО \"Джи Ти Эн Ти\"" },
                new Operator { Id = 64, ShortName = "", Name = "ЗАО \"ВЕСТ КОЛЛ ЛТД\"" },
                new Operator { Id = 65, ShortName = "", Name = "ООО \"Систематикс\"" },
                new Operator { Id = 66, ShortName = "", Name = "ООО \"Аврора Телеком\"" },
                new Operator { Id = 67, ShortName = "", Name = "ООО \"МиАТел\"" },
                new Operator { Id = 68, ShortName = "", Name = "Дальсвязь" },
                new Operator { Id = 69, ShortName = "", Name = "ОАО \"РТКомм.РУ\"" },
                new Operator { Id = 70, ShortName = "", Name = "ОАО \"Тывасвязьинформ\"" },
                new Operator { Id = 71, ShortName = "", Name = "ЗАО \"Вайнах Телеком\"" },
                new Operator { Id = 72, ShortName = "", Name = "ЗАО \"МИТ-ТЕЛ\"" },
                new Operator { Id = 73, ShortName = "", Name = "Северо-вост. Телеком" },
                new Operator { Id = 74, ShortName = "", Name = "Акционерное общество \"КОМСТАР ХМАО\"" },
                new Operator { Id = 75, ShortName = "", Name = "ЗАО \"Кабардино-Балкарская сотовая связь\"" },
                new Operator { Id = 76, ShortName = "", Name = "ЗАО \"Горно-Алтайская Сотовая Связь\"" },
                new Operator { Id = 77, ShortName = "", Name = "ОАО \"Северо-восточные Телекоммуникации\"" },
                new Operator { Id = 78, ShortName = "", Name = "Курганский Сотовый Телефон" },
                new Operator { Id = 79, ShortName = "", Name = "ММС Ингушетии" },
                new Operator { Id = 80, ShortName = "", Name = "Закрытое акционерное общество \"Финансовая Компания Императив\"" },
                new Operator { Id = 81, ShortName = "", Name = "ООО \"ЭСОТЕЛ-Рустелком\"" },
                new Operator { Id = 82, ShortName = "", Name = "ЗАО \"ДОЗОР-ТЕЛЕПОРТ\"" },
                new Operator { Id = 83, ShortName = "", Name = "ООО \"Открытая мобильная система\"" },
                new Operator { Id = 84, ShortName = "", Name = "ООО \"Спутниковые Мобильные Технологии\"" },
                new Operator { Id = 85, ShortName = "", Name = "ФГУП \"Морсвязьспутник\"" },
                new Operator { Id = 86, ShortName = "", Name = "ЗАО \"РадиоТел\"" },
                new Operator { Id = 87, ShortName = "", Name = "ЗАО \"Информационные транковые системы\"" },
                new Operator { Id = 88, ShortName = "", Name = "ООО \"Радиоимпульс\"" },
                new Operator { Id = 89, ShortName = "", Name = "МАГ" },
                new Operator { Id = 90, ShortName = "", Name = "ОАО \"Сургутнефтегаз\"" },
                new Operator { Id = 91, ShortName = "", Name = "ООО \"Метро-пэй\"" },
                new Operator { Id = 92, ShortName = "", Name = "ПАО \"Центральный телеграф\"" },
                new Operator { Id = 93, ShortName = "", Name = "ООО \"7к\"" },
                new Operator { Id = 94, ShortName = "", Name = "ООО \"Айконнект\"" },
                new Operator { Id = 95, ShortName = "", Name = "ООО \"Астрахань-Телеком\"" },
                new Operator { Id = 96, ShortName = "", Name = "ООО \"СервисПартнер\"" },
                new Operator { Id = 97, ShortName = "", Name = "ООО \"Интерком Технолоджи\"" },
                new Operator { Id = 98, ShortName = "", Name = "ООО \"Галс-Телеком\"" },
                new Operator { Id = 99, ShortName = "", Name = "ООО \"Телеком-Сервис\"" },
                new Operator { Id = 100, ShortName = "", Name = "ООО \"Центр 2М\"" },
                new Operator { Id = 101, ShortName = "", Name = "ООО \"Линк-Мастер\"" },
                new Operator { Id = 102, ShortName = "", Name = "ОАО \"Деловая Сеть - Иркутск\"" },
                new Operator { Id = 103, ShortName = "", Name = "ЗАО \"Интерсвязь-2\"" },
                new Operator { Id = 104, ShortName = "", Name = "ЗАО \"Экспресс ТелеКом\"" },
                new Operator { Id = 105, ShortName = "", Name = "ЗАО \"КантриКом\"" },
                new Operator { Id = 106, ShortName = "", Name = "С-Петербургский ММТ" },
                new Operator { Id = 107, ShortName = "", Name = "ЗАО \"МТУ-ИНФОРМ\"" },
                new Operator { Id = 108, ShortName = "", Name = "ООО \"Смолтелеком\"" },
                new Operator { Id = 109, ShortName = "", Name = "ООО \"Компьютерная скорая помощь\"" },
                new Operator { Id = 110, ShortName = "", Name = "ООО \"Фонеком\"" },
                new Operator { Id = 111, ShortName = "", Name = "ООО \"Элемтэ-Инвест\"" },
                new Operator { Id = 112, ShortName = "", Name = "ООО \"ИНТЕРТЕЛЕКОМ\"" },
                new Operator { Id = 113, ShortName = "", Name = "ГУП РК \"Крымтелеком\"" },
                new Operator { Id = 114, ShortName = "", Name = "ООО \"К-телеком\"" },
                new Operator { Id = 115, ShortName = "", Name = "ОАО \"МУРМАНСКИЙ ТРАЛОВЫЙ ФЛОТ\"" },

                //new Operator { Id = 0, Name = "", ShortName = "" },
            };
        }
    }
}
