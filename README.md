# TDD_1_ProductTestCase
TDD TestCase Practice

## 需求：
* 該11筆資料，如果要3筆成一組，取得Cost的總和的話，預期結果是 6,15, 24, 21
* 該11筆資料，如果是4筆一組，取得 Revenue 總和的話，預期結果會是 50,66,60
* 筆數輸入負數，預期會拋 ArgumentException
* 尋找的欄位若不存在，預期會拋 ArgumentException
* 筆數若輸入為0, 則傳回0
* 未來可能會新增其他欄位
* 希望這個API可以給其他 domain entity 用，例如 Employee
