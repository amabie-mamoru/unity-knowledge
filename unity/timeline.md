# Timeline

カットシーンやインゲームの演出シーケンスなどの映像演出を作成するツール

Timeline のメリットは分散開発する際にアーティストが Timeline で演出を組み、エンジニアはそれを再生するだけと分業することで連携オーバーヘッドを下げることが目的

## Timeline の内部構造

TimelineAsset ... Timeline で設定したデータの Asset
PlayableDirector ... TimelineAsset の再生器
PlayableGraph ... TimelineAsset 再生時に作成されるグラフ構造のデータ

使い方としては、 TimelineAsset を作り、シーンオブジェクトを PlayableDirector に設定すると、再生時、 PlayableDirector が PlayableGraph を作成し、それに則ってシーンオブジェクトにアニメーションを適応する

## 用語について

Tileline ではコントロール対象のシーンオブジェクトを再生する Timeline に紐づける処理をバインドという

## 注意点

Timeline は再生時に PlayableGraph 形式に変換されて実行されるため、再生開始後に TimelineAsset の状態を変えても反映されない

PlayableGraph に対して直接操作を行えば変更可能なように見えるがそれ用の API も存在しない

そのため、Timeline の挙動を変えたい場合は再生前に TimelineAsset をいじってから再生する必要がある

バインド状態も同様

一度 Timeline の再生をやめて再度バインドしてから再生する必要がある

## Timeline に標準で用意されている Track

### Activation Track

GameObject の Enable を切り替える Track

### Animation Track

Animator に対して AnimationClip を再生するための Track

連続再生や AnimationClip 間の Blend 設定も可能

## Audio Track

音を再生する

## Control Track

Particle System の再生に使われる

また、 Timeline の中で Timeline を入れ子にして再生するのにも使われる

### Playable Track

任意の Script を書いて Timeline で実行できる仕組み

### Signal Track

マーカーをおくと Signal が配置されたフレームが実行されると、バインドしているオブジェクトにイベントが飛ぶ

バインドした Object 側にイベントコールバックを飛ばす機能

### Marker

Signal と一緒。というか、Signal は Marker の拡張で作られている

## 拡張方法

Unity 公式サンプルとブログが参考になる

基本自由に拡張できる
