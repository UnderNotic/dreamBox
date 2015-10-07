using System;
using System.Collections.Generic;

namespace LoveMeBetter.Enums
{
    public enum RegionEnum
    {
        Dolnoslaskie = 1,
        KujawskoPomorskie = 2,
        Lubelskie = 3,
        Lubuskie = 4,
        Lodzkie = 5,
        Malopolskie = 6,
        Mazowieckie = 7,
        Opolskie = 8,
        Podkarpackie = 9,
        Podlaskie = 10,
        Pomorskie = 11,
        Slaskie = 12,
        Swietokrzyskie = 13,
        WarminskoMazurskie = 14,
        Wielkopolskie = 15,
        ZachodnioPomorskie = 16
    }

    public static class RegionEnumExt
    {
        private static Lazy<Dictionary<RegionEnum, string>> _mappedRegions = new Lazy<Dictionary<RegionEnum, string>>(() => new Dictionary<RegionEnum, string>
        {
            {RegionEnum.Dolnoslaskie, "dolnośląskie"},
            {RegionEnum.KujawskoPomorskie, "kujawsko-pomorskie"},
            {RegionEnum.Lubelskie, "lubelskie"},
            {RegionEnum.Lubuskie, "lubuskie"},
            {RegionEnum.Lodzkie, "łódzkie"},
            {RegionEnum.Malopolskie, "małopolskie"},
            {RegionEnum.Mazowieckie, "mazowieckie"},
            {RegionEnum.Opolskie, "opolskie"},
            {RegionEnum.Podkarpackie, "podkarpackie"},
            {RegionEnum.Podlaskie, "podlaskie"},
            {RegionEnum.Pomorskie, "pomorskie"},
            {RegionEnum.Slaskie, "śląskie"},
            {RegionEnum.Swietokrzyskie, "świętokrzyskie"},
            {RegionEnum.WarminskoMazurskie, "warmińsko-mazurskie"},
            {RegionEnum.Wielkopolskie, "wielkopolskie"},
            {RegionEnum.ZachodnioPomorskie, "zachodnio-pomorskie"}
        });

        public static IEnumerable<string> GetAllRegions()
        {
            return _mappedRegions.Value.Values;
        }

        public static string GetRegionString(RegionEnum regionEnum)
        {
            return _mappedRegions.Value[regionEnum];
        }
    }
}