# GameLauncher2024

## このリポジトリについて
2024年度文化祭にて販売するCD（DVD?）のゲームランチャーアプリ（Unity）
イメージはPS2のゲーム「ナムコミュージアム アーケードHits!」

## フォルダ構成について
~~Assets直下に入っている「Models」はアプリ内で使用するためのBlendファイルが入っている（制作用は「Working」の中）　モデリング技術のアル方は是非プルリクを~~
->やめました
## 使用するUnityのバージョン
2022.3.2.f1(入れてない場合はHubで入れてね♡)

## そのほか
完成したものについては[こちら](https://drive.google.com/file/d/1f2ZanLTRZ3WQfAvdtQESb8kQChUIw6lU/view?usp=drive_link)（ゲームの完全動作にはWebView2 RuntimeとVC_redistが必要）
部員向けのゲームのテンプレートについては[こちら](https://github.com/cydiawaltz/Game2024Template-SupportTools)（未完成）

## スクリプトとかのおおまかな役割
終盤になって、動くこと重視でｺﾞﾁｬﾘｺﾞﾁｬﾘとやっちゃったので、説明を追加

CallApps ->　読んで字の如く。ゲームを起動するやつ。.exe,.html,.batに対応。

CallApps1 ->　基本的には上のやつ。当日にテンポラリーに作ったやつなので、変数とかがめちゃくちゃ。

ChangeLow ->　低スペ版に切り替えるやつ。~~言うて低スペと高スペでランチャー自体の重さはそんなに変わらなかったんじゃないか疑惑~~

CheckStart ->　テスト。無視推奨。中身はChangeLowに発展。

DisplaySet ->　UIとかを解像度に応じて拡大縮小するやつ。(Canvas内専用)　これだけでも切り出して自分のリポで使っても可。

Fade ->　タイトル画面のあれ。２枚重ねている内のレイヤーが奥にある方用。

Fade2 ->　上に同じく。こっちは手前。

FirstBoot ->　初回起動に出すダイアログを出すやつ。

Guide ->　未使用？

KabegamiSet -> DisplaySetの壁紙版。デフォルトの縦横比に応じていい感じにできる。

KabegamiSize -> 未使用。

LoadHTMLGame -> ランチャー内でWebViewを呼び出そうとしてた残骸。

monitor -> 動画を入れようとしていた頃の残骸。(デザインと軽量化の観点で廃止)

MoveNext ->　カメラを回す。**これ重要。**

Movie ->　オープニングムービーを流す。

option -> オプションのボタンを押したときの関数群

Quit -> 重複起動したときのために、一定時間操作がなかったら自爆するスクリプト

seiretu -> バラバラのオブジェクトをきれいな円にするやつ

setInfoTex -> ゲームの説明欄用のDisplaySetみたいなやつ

TextsControll -> 未使用。

title -> ゲーム選択画面への遷移用

TurnOffAnim -> ゲーム選択画面の最初のアニメーションの終了を検知する

UIDraw -> ゲームの説明欄の実装。

~~書くの疲れた~~
スクリプト以外はcloneしてフォルダ見て下さい。

ねこはどこにでもいます。あとはよろしくおねがいします。よろしくおねがいしました。**かしこ。**
