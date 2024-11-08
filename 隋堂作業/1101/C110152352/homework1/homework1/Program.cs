using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class RetirementData
{
    public string 地區 { get; set; }
    public string 項目 { get; set; }
    public string 欄位名稱 { get; set; }
    public int 數值 { get; set; }
    public DateTime 資料時間日期 { get; set; }
    public string 資料週期 { get; set; }
}

public class Program
{
    public static void Main()
    {
        // 讀取 JSON 檔案
        string filePath = "D:/1108/homework1/1.json";
        string jsonData = File.ReadAllText(filePath);

        // 反序列化 JSON 資料
        List<RetirementData> data = JsonConvert.DeserializeObject<List<RetirementData>>(jsonData);

        // 找到數值最大的項目
        var maxRecord = data.OrderByDescending(d => d.數值).FirstOrDefault();

        // 找到數值最小的項目
        var minRecord = data.OrderBy(d => d.數值).FirstOrDefault();

        // 計算數值的平均值
        double averageValue = data.Average(d => d.數值);

        // 顯示結果
        Console.WriteLine("數值最大的退休項目：");
        if (maxRecord != null)
        {
            Console.WriteLine($"地區: {maxRecord.地區}");
            Console.WriteLine($"項目: {maxRecord.項目}");
            Console.WriteLine($"欄位名稱: {maxRecord.欄位名稱}");
            Console.WriteLine($"人數: {maxRecord.數值}");
            Console.WriteLine($"資料時間日期: {maxRecord.資料時間日期}");
        }

        Console.WriteLine("\n數值最小的退休項目：");
        if (minRecord != null)
        {
            Console.WriteLine($"地區: {minRecord.地區}");
            Console.WriteLine($"項目: {minRecord.項目}");
            Console.WriteLine($"欄位名稱: {minRecord.欄位名稱}");
            Console.WriteLine($"人數: {minRecord.數值}");
            Console.WriteLine($"資料時間日期: {minRecord.資料時間日期}");
        }

        Console.WriteLine($"\n退休人數的平均值: {averageValue:F2}");
    }
}
