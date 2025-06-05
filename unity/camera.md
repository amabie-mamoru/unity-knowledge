# Camera のお話

## Z-Fighting

FarClip と NearClip の範囲を広くしすぎる（例えばデフォルトの Near 0.3, Far 1000 とかにする）と、Depth 値の精度が足りず、カメラから遠いエリアでオブジェクトの重なりに不具合を生じることがある。これを Z-Fighting という。

![](./images/camera/z-fighting.png)

上記はデフォルトで白と赤の Plane を 0.001 だけ離して置いた場合の Z-Fighting の様子。距離 400 程度から発生する。

これは Near と Far の差が大きいと発生し、精度的にはデフォルトだと 10 くらいの距離で精度の半分くらいを使ってしまい、それ以降は精度が荒くなる

## カメラの設定

### Projection

Perspective の場合、 Near と Far の差が大きくなりすぎないように、基本は Far を 100 くらいに設定する

![](./images/camera/camera-config1.png)

### Renderring

ポストプロセスを使う場合は Post Processing をオンにする

往々にしてここがオフのままポストプロセスが反映されない！と悩むことがある

Render Shadows は UI の場合はオフにする

これによって描画コストを下げられる

Priority はカメラの描画順。同じだと順不同になるので必ず順番を決める

Culling Mask がカメラが描画する対象レイヤー

![](./images/camera/camera-config2.png)

### Environment

Background Type は Skybox 以外の場合は Uninitialized にする

Solid Color にすると塗りつぶすことになり意外と負荷が高い

よほどの事情があって背景を単色で塗りつぶした上でそれを描画して見せたい場合以外は Uninitialized にして背景に相当する 3D オブジェクトを描画することで描画回数を節約できる

最後に、Post Processing がオンになっている場合、 Solid Color の Alpha は書き出せず 1.0 で fill されてしまうという Unity 上の仕様があるので注意!!

![](./images/camera/camera-config3.png)

### Output

MSAA はオフにする

これは4倍で一度描画したものを4倍に縮小して表示することで美麗に出力するためのオプションで、 PC ゲームの場合はオンにして綺麗な画面を見せることがあるが、モバイルでは基本オフで OK

![](./images/camera/camera-config4.png)

## カメラスタック

レイヤーに分けてカメラで描画して後で統合して描画するための機能

Base Layer (3D) → UI Layer → Overlay Layer → Transition Layer と分けるのがよい

ちなみに、どこかのカメラでポストエフェクトをかけると全体に影響があるので注意!!

また、言うてもカメラが増えるので処理負荷は大きい

そのため、カメラからの奥行きを調整して重なり具合で解決できないかを検討する

たとえば UI の場合は Canvas 単位で Canvas.planeDistance や sortingLayer が使える

VFX をオブジェクトの全面に出したい場合は、描画レイヤーを分けるのではなく、オブジェクト単位で描画順コントロール機能を使う

ちなみに、レイヤー数に比例してカメラが毎フレーム行う描画のためのセットアップコスト（Main Thread / Render Thread）の負荷が上がり、高スペック端末であれば 10 くらいは耐えられるが、低スペック端末の場合、カメラ 1 台につき 1ms〜 CPU コストが増える

余談

面白い使い方に描画レイヤーを変更したり GameObject をオフにせず、 Camera の Culling Mask を変更して見えなくすると言う方法がある

これを採用すると、 GameObject がオンになった時に走ってしまう処理を気にしなくてよくなるという利点がある

仕組みについても少し触れると、カメラスタックは順々に上書き描画してる（いわゆる隠れる部分とかは考えず描画が走っている）
