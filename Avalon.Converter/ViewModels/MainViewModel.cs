using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.ComponentModel;
using System.Net;
using System.Text.RegularExpressions;
using ReactiveUI;

namespace Avalon.Converter.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ObservableCollection<Course> Course { get; set; }

    public MainViewModel()
    {
        var course = new List<Course>
        {
            new Course("Доллар", GetCourse(Currency.USD)),
            new Course("Юань", GetCourse(Currency.CNY)),
            new Course("Канадский доллар", GetCourse(Currency.CAD)),
            new Course("Гонгонский доллар", GetCourse(Currency.HKD)),
            new Course("Чешская крона", GetCourse(Currency.CZK)),
            new Course("Австралийский доллар", GetCourse(Currency.AUD)),
            new Course("Казахский тенге", GetCourse(Currency.KZT)),
        };
        Course = new ObservableCollection<Course>(course);
    }

    private float GetCourse(Currency currency)
    {
        string line = "";
        Match match = null;
        switch (currency)
        {
            case Currency.USD:
                using (WebClient wc = new())
                {
                    line = wc.DownloadString("https://www.cbr-xml-daily.ru/daily_utf8.xml");
                }
                match = Regex.Match(line, "<Name>Доллар США</Name><Value>(.*?)</Value>");
                return float.Parse(match.Groups[1].Value);
                break;
            case Currency.EUR:
                using (WebClient wc = new())
                {
                    line = wc.DownloadString("https://www.cbr-xml-daily.ru/daily_utf8.xml");
                }
                match = Regex.Match(line, "<Name>ЕВРО</Name><Value>(.*?)</Value>");
                return float.Parse(match.Groups[1].Value);
                break;
            case Currency.HKD:
                using (WebClient wc = new())
                {
                    line = wc.DownloadString("https://www.cbr-xml-daily.ru/daily_utf8.xml");
                }
                match = Regex.Match(line, "<Name>Гонконгский доллар</Name><Value>(.*?)</Value>");
                return float.Parse(match.Groups[1].Value);
                break;
            case Currency.KZT:
                using (WebClient wc = new())
                {
                    line = wc.DownloadString("https://www.cbr-xml-daily.ru/daily_utf8.xml");
                }
                match = Regex.Match(line, "<Name>Казахстанских тенге</Name><Value>(.*?)</Value>");
                return float.Parse(match.Groups[1].Value);
                break;
            case Currency.AUD:
                using (WebClient wc = new())
                {
                    line = wc.DownloadString("https://www.cbr-xml-daily.ru/daily_utf8.xml");
                }
                match = Regex.Match(line, "<Name>Австралийский доллар</Name><Value>(.*?)</Value>");
                return float.Parse(match.Groups[1].Value);
                break;
            case Currency.CNY:
                using (WebClient wc = new())
                {
                    line = wc.DownloadString("https://www.cbr-xml-daily.ru/daily_utf8.xml");
                }
                match = Regex.Match(line, "<Name>Китайский юань</Name><Value>(.*?)</Value>");
                return float.Parse(match.Groups[1].Value);
                break;
            case Currency.CAD:
                using (WebClient wc = new())
                {
                    line = wc.DownloadString("https://www.cbr-xml-daily.ru/daily_utf8.xml");
                }
                match = Regex.Match(line, "<Name>Канадский доллар</Name><Value>(.*?)</Value>");
                return float.Parse(match.Groups[1].Value);
                break;
            case Currency.CZK:
                using (WebClient wc = new())
                {
                    line = wc.DownloadString("https://www.cbr-xml-daily.ru/daily_utf8.xml");
                }
                match = Regex.Match(line, "<Name>Чешских крон</Name><Value>(.*?)</Value>");
                return float.Parse(match.Groups[1].Value);
                break;
        }
        
        return 0;
    }
}