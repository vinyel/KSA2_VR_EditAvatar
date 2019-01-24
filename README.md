# KSA2_VR_EditAvatar
- 研究用に開発したUnityプロジェクトのアバタ編集システムです。
- このシステムを使ってプロテウス効果を研究していました。
- 3Dアバタを着替えさせたりすることができます。
- この開発を通して、UnityとBlenderの使い方をある程度習得しました。

![aes](https://user-images.githubusercontent.com/25292248/51665498-38b4b800-1fff-11e9-9120-f80df15e3276.gif)

## プロテウス効果
Yeeらが以下を提唱
- 仮想空間上で魅力的な見た目のアバターを用いると、対人距離を詰める、自己開示をする。【Ⅰ】
- 上記のような行動をとり続ける態度が、現実世界にも表れる。【Ⅱ】

つまり、アバタの見た目とユーザの積極性や外向性が互いに作用する現象と言えます。  
このプロテウス効果を研究室で開発していたVRシステムにおける仮想空間内での外向性によって評価し、アバタ編集システムの有用性を検証していました。 

【Ⅰ】Yee, N. and Bailenson, JN. 2007. The Proteus Effect: The Effect of Transformed Self-Representation on Behavior. Human Communication Research, ISSN 0360-3989, 33, 271–290.   
【Ⅱ】Yee, N., Bailenson, JN. and Ducheneaut, N. 2009. The Proteus Effect: Implications of Transformed Digital Self-Representation on Online and Offline Behavior. Communication Research, 33(2), 285–312. 

## 開発環境
### ・Unity
アバタ編集システムの開発用のゲームエンジン
### ・Blender
3Dアバタのモデリング用のモデリングソフト

## アバタ編集システム
- 3Dアバタなどは自作ですが、モーションはアセットストアの物を利用しました。
- 3Dアバタの衣装の変更機能と肌や衣装の色の変更機能があります。
- 性別、髪型、服やズボン、アクセサリ、各々の色を変更可能です。
- 操作はゲームパッド、またはキーボードとマウスです。

### アバタの編集項目
編集可能なのは、性別、髪型、服やズボン、アクセサリ、各々の色です。  
肌の色は4色、衣装などの色は15色です。  
男女ともに、髪型は5種類、服は4種類、ズボンは3種類、アクセサリは3種類からそれぞれ選択が可能です。

<img src=https://user-images.githubusercontent.com/25292248/51663428-21bf9700-1ffa-11e9-8f13-e210c70b9d44.png width=320>
<img src=https://user-images.githubusercontent.com/25292248/51663429-21bf9700-1ffa-11e9-845c-b29bbe51b78e.png width=320>
<img src=https://user-images.githubusercontent.com/25292248/51663426-21bf9700-1ffa-11e9-8598-18ba940728d2.png width=320>

- 男性アバタの編集項目
<img src=https://user-images.githubusercontent.com/25292248/51663444-2be19580-1ffa-11e9-8de9-8d8ca4ddf6be.PNG width=320>

- 女性アバタの編集項目
<img src=https://user-images.githubusercontent.com/25292248/51663446-2be19580-1ffa-11e9-9fb5-0b9ae8a4f9e0.PNG width=320>

## 編集結果例
<img src=https://user-images.githubusercontent.com/25292248/51663438-25ebb480-1ffa-11e9-8294-836f6ac43234.PNG width=320>

## 実装で苦労したところ
UnityもBlenderも利用したことがなく、まったくの初心者の状態から開発を始めたので、分からないことだらけでした。  
また、システムの仕組みで、3Dアバタの衣装オブジェクトをどのように切り替えるか、参考にできるサイトがなかったため、自分で考える必要がありました。  
衣装などをより多く用意するためのモデリングも大変でした。

## 最後に
- 開発を通して、Unityを用いたシステム開発とBlenderによる3DCGモデリングに慣れることができました。
  - 特に人間の3Dモデリングをしたことで、モデリング・リギング・マテリアル・テクスチャ・シェーダーの知識を一通り習得できたことは大きいと考えています。
- Blenderのモデリング経験を活かし、3DCG制作のアルバイトをしています。
- 振り返ってみると、とても充実した研究でした。
