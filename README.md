# RAFF
Simple android game, where you have to protect player from hitting spikes, and collect points.

>Main purpose was to learn implementation of : Skins system, In App Purchases with Google Play Store, managing data (coin balance, highscore etc) through requests to web services.

Game client uses web service written in PHP to operate on MySQL database, communication is simple yet protected with MD5 hashing and private key.
Client checks for internet connection and actively adjusts game flow.
<img src="https://raw.githubusercontent.com/drcrappygames/RAFF/master/README/Images/NoInternetConnection.png">

Working skins system allows you to choose both Color and Sprite for player and borders, and can be easily extended with diffrent skins, and different skin targets (f. eg. points, or enemies). Chosen skin data is persisted in internal memory, so your selections will be saved even while beeing offline.
<img src="https://raw.githubusercontent.com/drcrappygames/RAFF/master/README/Images/BasicSkin.png">
<img src="https://raw.githubusercontent.com/drcrappygames/RAFF/master/README/Images/ChangingSkin.png">
<img src="https://raw.githubusercontent.com/drcrappygames/RAFF/master/README/Images/ChangedSkin.png">
