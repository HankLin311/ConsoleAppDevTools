# ConsoleAppDevTools

`ConsoleAppDevTools` 是一組幫助 C# 控制台應用程式開發的工具，包括 `StepManager` 和 `Helper` 兩塊功能。

### StepManager

是用來管理和執行流程步驟的工具，可以讓每個步驟按順序執行並在控制台顯示進度。支援同步與非同步步驟，並提供錯誤處理功能。

### Helper

是將控制台應用程式中常用的語法進行封裝，方便開發時快速重複使用。這些方法可以簡化顯示訊息、錯誤處理等工作。

---

## 功能說明

### StepManager - 執行流程 (Run) 和 步驟 (Step)

- **Run**：啟動整個流程，記錄開始與結束時間，並處理錯誤。
  
- **Step**：定義每個步驟，支持有無參數與返回值的同步和非同步執行。

---

## 使用範例

```csharp
await StepManager.RunAsync(async () =>
{
    StepManager.Step("第一步", () => Console.WriteLine("第一步完成"));
    
    string result1 = StepManager.Step("第二步：傳回結果", () => "結果123");

    string result2 = await StepManager.StepAsync("第三步：傳入結果，並返回新結果", result1, async input =>
    {
        await Task.Delay(1000);
        return input + "456";
    });

    Console.WriteLine("最終結果：" + result2);
});


/*
  以下為輸出結果:

  ---------------------------------------
  第一步 執行中...
  第一步完成
  ---------------------------------------
  第二步：傳回結果 執行中...
  ---------------------------------------
  第三步：傳入結果，並返回新結果 執行中...
  最終結果：結果123456
  ---------------------------------------
  startTime: 2024/11/25 14:00:00
  endTime: 2024/11/25 14:00:03
  ---------------------------------------
  Press 'X' to exit.

*/


