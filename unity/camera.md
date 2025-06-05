# Camera のお話

## Z-Fighting

FarClip と NearClip の範囲を広くしすぎる（例えばデフォルトの Near 0.3, Far 1000 とかにする）と、Depth 値の精度が足りず、カメラから遠いエリアでオブジェクトの重なりに不具合を生じることがある。これを Z-Fighting という。

![](./images/camera/z-fighting.png)

上記はデフォルトで白と赤の Plane を 0.001 だけ離して置いた場合の Z-Fighting の様子。距離 400 程度から発生する。

これは Near と Far の差が大きいと発生し、精度的にはデフォルトだと 10 くらいの距離で精度の半分くらいを使ってしまい、それ以降は精度が荒くなる
