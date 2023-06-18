# Diamond-Stack-Game
This is a demo for Flush Games


Hareket:
Karakter yavaş giderken yürüme, hızlanınca koşma animasyonu. Dururken de Idle animasyonu çalışıyor.


Grid:
Editör üzerinden satır ve sütunlarını ayarlayabilinen bir grid sistemi mevut.

Gem Yetiştirme:
Gridlerin üzerinde çıkan gemler yavaşça büyümeye başlıyor 5 saniye içinde full büyüklüğe geliyor. 0.25 scale'i geçmeden toplanmıyor ve büyüdükçe değerleri artıyor. Karakter yerden alınca büyümesi durur.


Gem Satış:
Belirtilen noktaya gidince sınırsız yapılabilen stack gemlerimiz 0.3 saniyede 1 satılmaya başlıyor (gem formülü : Başlangıç Satış Fiyatı + scale Birimi * gemÇeşidiBaşlangıçFiyatı)

Pop-up

Buton ile açılır kapanır bir pop-up var. Her gem için fiyat, gem resmi ve gem adı gösteriyor. Scriptable obje ile data verildiği için yeni gem eklemek için datayı oluşturmak yeterli. Otomatik olarak yeni
için instantiate edecektir.
