https://youtu.be/btJohmTrtGM
https://github.com/960129eric-ops/1151VR-HW4-414262636-ChienHungAn


1. 核心功能與架構
移動與視角：飛機具備持續前進的動態機制，並配合平滑跟隨攝影機（Smooth Follow）隨時追蹤玩家視角。
音效管理系統：配置了雙 AudioSource 機制，分別處理持續循環播放的飛機引擎飛行音效，以及觸發時播放的一次性音效。
狀態與回饋：當飛機與設定了 Obstacle 標籤的障礙物（大樓）發生碰撞時，會即時停止引擎音效並播放撞擊爆炸聲；同時支援設置 PassCheck 觸發區來播放順利通過的音效回饋。
2. 物件與設定機制
飛機 (Plane)：掛載了 AircraftController 控制腳本、具備碰撞器（Collider），以及設定了 Is Kinematic 的 Rigidbody（剛體），完美解決物理系統與程式碼位移的衝突。
障礙物與關卡 (Skyscraper)：透過 Mesh Collider 並勾選 Is Trigger，結合 Obstacle 標籤來精準觸發事件。關卡設計上採雙大樓佈局——第一棟置於左側供玩家閃避，第二棟置於正前方測試直擊撞毀的判定。
操作:利用wasd進行上下左右移動
