# HeavenlyHR 人力資源管理系統

是一套使用 C# (.NET 8) 建置的後端人力資源管理系統。

專案名稱象徵以「初心與目標」為核心價值，打造理想中的 HR 系統。

天 : 象徵著高尚的理想與目標，表示對未來的追求和無限的可能性。

心 : 代表著堅持初心和信念，強調對人才的重視與關懷。

Heavenly : 傳達出系統的卓越性和非凡價值，強調其在人才管理方面的優越表現。

# 系統模組功能

- 員工管理 **Employee**：集中管理員工的基本資料，提升人力資源的效率。
  - 建立、查詢、更新、刪除員工基本資料
  - 員工欄位包含姓名、到職日、主管、手機、地址、電子信箱等多項資訊
- 員工異動 **Employee Change**
  - 記錄員工異動類型（如：離職、復職、內部異動）
  - 支援異動方式(自動/手動)、異動生效日、核准日、申請日與異動原因
- 員工關聯資料匯出 **Export**
  - 將目前所有員工資料匯出為 `employees_export.csv`
  - 自動產出於執行目錄中，方便後續報表或備份使用
- 招募管理：有效管理人才庫和編制，確保招募流程的順暢。(已開發)
  - 人才庫 **Candidate** (已開發)
 
- 考勤管理：全面監控考勤狀況，簡化加班和請假流程。(待開發)

- 薪資管理：自動化薪資計算及各類保險的管理，確保準確性和合規性。(待開發)

- 績效管理：幫助企業設定目標、進行360度反饋，提升員工績效。(待開發)

- 訓練管理：規劃和管理員工的培訓與學習歷程，促進專業成長。(待開發)

- 數據中心儀表板管理：提供數據分析和報表功能，幫助管理層作出明智決策。(待開發)

# 技術架構
| 項目 | 技術 |
|------|------|
| 語言 | C# 11 / .NET 8 |
| ORM | Entity Framework Core |
| 資料庫 | MySQL (使用 DBeaver 操作) |
| 開發工具 | JetBrains Rider 2025 |
| 架構 | Repository + Service Pattern |

# 專案架構
```
HeavenlyHR/
├── Models/
│ └── Employee.cs
│ └── EmployeeChange.cs
├── Data/
│ └── AppDbContext.cs
├── Repositories/
│ └── EmployeeRepository.cs
│ └── EmployeeChangeRepository.cs
├── Services/
│ └── EmployeeService.cs
│ └── EmployeeChangeService.cs
│ └── ExportService.cs
├── Helpers/
│ └── CsvExporter.cs
├── Program.cs
└── appsettings.json
```

# 作者
- 開發者 : Chen Sheng-Yen
- GitHub : https://github.com/ShengYen77
- 系統理念 : 透過結合自身過去的經歷與現在的歷練，以「初心與目標」為核心價值，打造理想中的 HR 系統。

