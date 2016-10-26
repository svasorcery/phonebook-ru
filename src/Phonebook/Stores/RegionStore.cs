using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Stores
{
    public class RegionStore
    {
        private List<Region> _regions;

        public RegionStore()
        {
            InitStore();
        }


        public List<Region> All()
        {
            return _regions;
        }

        public List<string> ToList()
        {
            return _regions.Select(x => x.Name).ToList();
        }

        public Region Find(int num)
        {
            try
            {
                return _regions.First(x => x.Id == num);
            }
            catch (Exception e)
            {
                throw new ArgumentNullException($"Запись с id={num} не найдена", e);
            }
        }

        public Region[] Search(string name)
        {
            return _regions.Where(x => x.Name.ToLower().Contains(name.Trim().ToLower())).ToArray();
        }


        private void InitStore()
        {
            _regions = new List<Region>
            {
                //new Region { Id =  0, TimeZoneSpan = 0, Name = "Российская Федерация" },
                new Region { Id =  1, TimeZoneSpan = 0, Name = "Республика Адыгея" },
                new Region { Id =  2, TimeZoneSpan = 2, Name = "Республика Башкортостан" },
                new Region { Id =  3, TimeZoneSpan = 5, Name = "Республика Бурятия" },
                new Region { Id =  4, TimeZoneSpan = 4, Name = "Республика Алтай" },
                new Region { Id =  5, TimeZoneSpan = 0, Name = "Республика Дагестан" },
                new Region { Id =  6, TimeZoneSpan = 0, Name = "Республика Ингушетия" },
                new Region { Id =  7, TimeZoneSpan = 0, Name = "Кабардино-Балкарская Республика" },
                new Region { Id =  8, TimeZoneSpan = 0, Name = "Республика Калмыкия" },
                new Region { Id =  9, TimeZoneSpan = 0, Name = "Карачаево-Черкесская Республика" },
                new Region { Id = 10, TimeZoneSpan = 0, Name = "Республика Карелия" },
                new Region { Id = 11, TimeZoneSpan = 0, Name = "Республика Коми" },
                new Region { Id = 12, TimeZoneSpan = 0, Name = "Республика Марий Эл" },
                new Region { Id = 13, TimeZoneSpan = 0, Name = "Республика Мордовия" },
                new Region { Id = 14, TimeZoneSpan = 6, Name = "Республика Саха (Якутия)" },
                new Region { Id = 15, TimeZoneSpan = 0, Name = "Республика Северная Осетия - Алания" },
                new Region { Id = 16, TimeZoneSpan = 0, Name = "Республика Татарстан" },
                new Region { Id = 17, TimeZoneSpan = 4, Name = "Республика Тыва" },
                new Region { Id = 18, TimeZoneSpan = 1, Name = "Удмуртская Республика" },
                new Region { Id = 19, TimeZoneSpan = 4, Name = "Республика Хакасия" },
                new Region { Id = 20, TimeZoneSpan = 0, Name = "Чеченская Республика" },
                new Region { Id = 21, TimeZoneSpan = 0, Name = "Республика Чувашия" },
                new Region { Id = 22, TimeZoneSpan = 4, Name = "Алтайский край" },
                new Region { Id = 23, TimeZoneSpan = 0, Name = "Краснодарский край" },
                new Region { Id = 24, TimeZoneSpan = 4, Name = "Красноярский край" },
                new Region { Id = 25, TimeZoneSpan = 7, Name = "Приморский край" },
                new Region { Id = 26, TimeZoneSpan = 0, Name = "Ставропольский край" },
                new Region { Id = 27, TimeZoneSpan = 7, Name = "Хабаровский край" },
                new Region { Id = 28, TimeZoneSpan = 6, Name = "Амурская область" },
                new Region { Id = 29, TimeZoneSpan = 0, Name = "Архангельская область" },
                new Region { Id = 30, TimeZoneSpan = 1, Name = "Астраханская область" },
                new Region { Id = 31, TimeZoneSpan = 0, Name = "Белгородская область" },
                new Region { Id = 32, TimeZoneSpan = 0, Name = "Брянская область" },
                new Region { Id = 33, TimeZoneSpan = 0, Name = "Владимирская область" },
                new Region { Id = 34, TimeZoneSpan = 0, Name = "Волгоградская область" },
                new Region { Id = 35, TimeZoneSpan = 0, Name = "Вологодская область" },
                new Region { Id = 36, TimeZoneSpan = 0, Name = "Воронежская область" },
                new Region { Id = 37, TimeZoneSpan = 0, Name = "Ивановская область" },
                new Region { Id = 38, TimeZoneSpan = 5, Name = "Иркутская область" },
                new Region { Id = 39, TimeZoneSpan =-1, Name = "Калининградская область" },
                new Region { Id = 40, TimeZoneSpan = 0, Name = "Калужская область" },
                new Region { Id = 41, TimeZoneSpan = 9, Name = "Камчатская область" },
                new Region { Id = 42, TimeZoneSpan = 4, Name = "Кемеровская область" },
                new Region { Id = 43, TimeZoneSpan = 0, Name = "Кировская область" },
                new Region { Id = 44, TimeZoneSpan = 0, Name = "Костромская область" },
                new Region { Id = 45, TimeZoneSpan = 2, Name = "Курганская область" },
                new Region { Id = 46, TimeZoneSpan = 0, Name = "Курская область" },
                new Region { Id = 47, TimeZoneSpan = 0, Name = "Ленинградская область и г. Санкт-Петербург" },
                new Region { Id = 48, TimeZoneSpan = 0, Name = "Липецкая область" },
                new Region { Id = 49, TimeZoneSpan = 7, Name = "Магаданская область" },
                new Region { Id = 50, TimeZoneSpan = 0, Name = "Московская область и г. Москва" },
                new Region { Id = 51, TimeZoneSpan = 0, Name = "Мурманская область" },
                new Region { Id = 52, TimeZoneSpan = 0, Name = "Нижегородская область" },
                new Region { Id = 53, TimeZoneSpan = 0, Name = "Новгородская область" },
                new Region { Id = 54, TimeZoneSpan = 3, Name = "Новосибирская область" },
                new Region { Id = 55, TimeZoneSpan = 3, Name = "Омская область" },
                new Region { Id = 56, TimeZoneSpan = 2, Name = "Оренбургская область" },
                new Region { Id = 57, TimeZoneSpan = 0, Name = "Орловская область" },
                new Region { Id = 58, TimeZoneSpan = 0, Name = "Пензенская область" },
                new Region { Id = 59, TimeZoneSpan = 2, Name = "Пермская область" },
                new Region { Id = 60, TimeZoneSpan = 0, Name = "Псковская область" },
                new Region { Id = 61, TimeZoneSpan = 0, Name = "Ростовская область" },
                new Region { Id = 62, TimeZoneSpan = 0, Name = "Рязанская область" },
                new Region { Id = 63, TimeZoneSpan = 1, Name = "Самарская область" },
                new Region { Id = 64, TimeZoneSpan = 0, Name = "Саратовская область" },
                new Region { Id = 65, TimeZoneSpan = 8, Name = "Сахалинская область" },
                new Region { Id = 66, TimeZoneSpan = 2, Name = "Свердловская область" },
                new Region { Id = 67, TimeZoneSpan = 0, Name = "Смоленская область" },
                new Region { Id = 68, TimeZoneSpan = 0, Name = "Тамбовская область" },
                new Region { Id = 69, TimeZoneSpan = 0, Name = "Тверская область" },
                new Region { Id = 70, TimeZoneSpan = 3, Name = "Томская область" },
                new Region { Id = 71, TimeZoneSpan = 0, Name = "Тульская область" },
                new Region { Id = 72, TimeZoneSpan = 2, Name = "Тюменская область" },
                new Region { Id = 73, TimeZoneSpan = 1, Name = "Ульяновская область" },
                new Region { Id = 74, TimeZoneSpan = 2, Name = "Челябинская область" },
                new Region { Id = 75, TimeZoneSpan = 6, Name = "Забайкальский край" },
                new Region { Id = 76, TimeZoneSpan = 0, Name = "Ярославская область" },
                new Region { Id = 77, TimeZoneSpan = 0, Name = "г. Москва" },
                new Region { Id = 78, TimeZoneSpan = 0, Name = "г. Санкт-Петербург" },
                new Region { Id = 79, TimeZoneSpan = 7, Name = "Еврейская автономная область" },
                new Region { Id = 80, TimeZoneSpan = 5, Name = "Агинский Бурятский автономный округ" },
                new Region { Id = 81, TimeZoneSpan = 0, Name = "Коми-Пермяцкий автономный округ" },
                new Region { Id = 82, TimeZoneSpan = 9, Name = "Корякский автономный округ" },
                new Region { Id = 83, TimeZoneSpan = 0, Name = "Ненецкий автономный округ" },
                new Region { Id = 84, TimeZoneSpan = 4, Name = "Таймырский (Долгано-Ненецкий) автономный округ" },
                new Region { Id = 85, TimeZoneSpan = 5, Name = "Усть-Ордынский Бурятский автономный округ" },
                new Region { Id = 86, TimeZoneSpan = 2, Name = "Ханты-Мансийский автономный округ - Югра" },
                new Region { Id = 87, TimeZoneSpan = 9, Name = "Чукотский автономный округ" },
                new Region { Id = 88, TimeZoneSpan = 4, Name = "Эвенкийский автономный округ" },
                new Region { Id = 89, TimeZoneSpan = 2, Name = "Ямало-Ненецкий автономный округ" },
                new Region { Id = 92, TimeZoneSpan = 0, Name = "Республика Крым и г. Севастополь" },
                new Region { Id = 99, TimeZoneSpan = 3, Name = "г. Байконур" },
            };
        }
    }
}
