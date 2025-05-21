# C#の歴史

C# が生まれた年。

その頃には、 Java、C++、VB6、Delphi、Perl/PHP といった言語がいた。

Java は Web と業務システムの主流として、 C++ はゲーム・システム系の中心として、 VB6 は Windows アプリとして、 Delphi は GUI に強い業務向けとして、 Perl/PHP は動的な Web 特化開発として名を揚げていた。

その中でも Sun Microsystems が開発した Java が爆発的に普及した。Java はマルチプラットフォーム("Write Once, Run Anywhere")を掲げ、Web サーバやエンタープライズアプリの主流言語になっていった。

Microsoft は当時、主に C++/VB で Windowsアプリを構築していたが、Java の台頭で Windows に依存する開発環境が時代遅れに見られ始めたため、その危機意識として危機感を覚えていた。

そんな中、 Microsoft も Java VM をライセンスしていたが、 Sun との法的対立(※J++問題)により Java 互換戦略が崩壊。その代替として、「自社手動でのモダンな言語とランタイム」の必要に迫られた。

C# は Java をお手本にしつつも、 Windows に特化した "現代的で強力な代替言語" として設計された。

ちなみに、そのときのランタムが .NET Framework のこと。言語に依存せず、 C#、VB.NET、F#、C++/CLIなどを共通基盤で動かせる。また、ファイルIO、ネットワーク、DB、UI、暗号などを統一 API で提供し共通ライブラリを備えた統合プラットフォームとして扱われた。

余談だが、J++問題についても触れておくと、J++ とは Microsoft が Java のライセンスを受けて開発した Java 互換の独自開発環境・言語。 Visual Studio に統合されており、 Windows アプリ開発に強化された Java を提供していた。正式名称は Visual J++。

Microsoft は Java 標準を逸脱して独自拡張を追加を行った。これにより Microsoft 製の Java アプリは他の Java プラットフォームでは動かないものが増えた。これは Write Once, Run Anywhere の Java の哲学に反したため、 Sun は「Java の商標ライセンス違反」として Microsoft を提訴（1997年）。翌年には Microsoft は J++ の開発を停止せざるを得なくなり、 2001年には若いするものの、 Microsoft は Java のライセンスを永久に失った。これにより C# の必要に迫られた。

もう少し深掘りして、なぜ Microsoft は独自拡張したのかというと、 Java の仕様では、 Windows API との深い統合が困難だった。なぜかというと、 Microsoft は Windows を主力とする企業であり、 Java が「Windows の支配力を弱める存在」と感じていたため。結果として、 Java の設計思想とは対立的な「Windows に最適化された Java」を追求した。


