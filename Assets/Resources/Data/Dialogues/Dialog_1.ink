INCLUDE CrossExamError.ink

#Speaker:???-1
Isso é injusto. Eu sou melhor que os outros. Eu! É óbvio!

#Speaker:???-1
É tudo culpa dele! Essa fita tinha que ser minha! Quem ele pensa que é?

#Speaker:???-2
Ei! O que você está fazendo na carteira do Dexter?

#Speaker:???-1
Gugh!

#Speaker:???-1
Droga! Achei que não tinha ninguém perto... Cuida da sua vida, sai daqui!

#Speaker:???-2
Isso é roubo! Coloca de volta na mochila dele!

#Speaker:???-1
E você vai fazer o que se eu não devolver?

#Action:opening-transit
#Opening:case-1
((empty))

#Speaker:Elise
#Color:Blue
(Que saco... Já deu 17h, só devolvam o jogo do menino)

#Speaker:Professora
É como eu falei, vamos ficar aqui até resolvermos esse problema. Dexter, nos conte de novo o que aconteceu.

#Speaker:Dexter
Eu... Eu estava no recreio e fui chamado pra sala dos professores. Decidi pegar a chave e passar na sala antes para deixar meu gameboy na mochila.

#Speaker:Dexter
Quando voltei já estávamos em aula, então fui para meu lugar. Só mais tarde me dei conta que ele não estava mais aqui!

#Speaker:Howard
Obviamente alguém deve ter pego antes do intervalo terminar, e eu lembro de você ter sido chamado pelo Jack durante o recreio.

#Speaker:Howard
Você não teria nada a ver com isso, Jack? Óbvio, você anda muito ligado a esse tipo de confusão.

#Speaker:Jack
O quê? Ma-Mas eu só fui chamá-lo por um pedido dos professores! Eu não tenho nada a ver com isso!

#Speaker:Elise
#Color:Blue
(É… Jack sempre leva a culpa pelos problemas da escola. Acho que é por conta da altura dele, intimida um pouco. Se bem que ele não parece ser um cara mau...)

#Speaker:Elise
#Color:Blue
(Mas como eu não tenho nada a ver com isso acho que vou ficar na minha, né?)

#Speaker:Howard
Mas não foi você o culpado pelo roubo daquele jogo de cartas um dia desses?

#Speaker:Howard
Obviamente que eu vi como você olhou pro gameboy de Dexter enquanto ele jogava NBA Super Jam.

#Speaker:Elise
#Color:Blue
(Espera! Esse não é aquele jogo novo de basquete!?)

#Speaker:Elise
#Color:Blue
(Não vou ficar na reserva! Vou ter que entrar em campo e fazer justiça!)

#Speaker:Howard
Se o que diz é verdade, mostre-nos o que você tem na mochila!

#Speaker:Jack
Mas eu também não tenho nada a ver com as cartas! Quer ver? Olhe então!

#Action:show-picture
#Picture:case-1-backpack-1
((empty))

#Speaker:Professora
Basta. É verdade que Jack foi chamar o Dexter a pedido de nós professores. Ele estava na diretoria antes disso acontecer.

#Speaker:Professora
Jack. Você roubou ou não o videogame?

#Speaker:Jack
Não fui eu, eu já falei!

#Speaker:Howard
Então é óbvio que você vai nos falar o que é isso aqui.

#Action:show-picture
#Picture:case-1-backpack-2
((empty))

#Color:Green
"Foi Ele!" \n “Incrível, ele ta sempre se metendo em encrenca.”

#Color:Green
“Não me surpreende que ele não admita a verdade.” \n “Uma vez encrenqueiro, sempre encrenqueiro.”

#Speaker:Jack
O quê?! Mas não fui eu! A-Alguém deve ter colocado aí para me incriminar!

#Speaker:Elise
E se Jack estiver falando a verdade? Vão realmente botar a culpa dele assim sem saber?

#Color:Green
[SILÊNCIO]

#Speaker:Elise
Pode ser que não tenha sido ele, e o verdadeiro culpado está se escondendo!

#Speaker:Elise
Em nome do basquete, eu me encarrego de dar assistência!

#Color:Green
[SILÊNCIO E CONSTRANGIMENTO]

#Speaker:Howard
Heh, é óbvio que o culpado é o Jack, afinal quem mais poderia ser?

#Speaker:Howard
Mas, ao que parece, vou ter que contar minha versão dos fatos.

#Speaker:Professora
Howard, você sabe de alguma coisa?

#Speaker:Howard
É óbvio que eu sei, só não achei que seria necessário me pronunciar diante de tanta obviedade! Mas justiça é justiça, certo?

#Speaker:Professora
Pois bem, Howard. Você vai nos contar o que viu, e eu quero que você...

#Speaker:Professora
Você que havia se levantado. Qual o seu nome?

->whatIsYourName
== whatIsYourName ==
* [Elise Watson] -> myNameIsRight 
* [Taylor Swift] -> myNameIsWrongTaylor 
* [Scarlett Johansson] -> mynameIsWrongScarlet

== mynameIsWrongScarlet ==
#Speaker:Elise
Meu nome é Scarlett Johansson

#Speaker:Professora
Scarlett Johansson... Sei, esse é seu nome né?

#Speaker:Elise
Precisamente, professora!

#Speaker:Professora
Você é uma atriz então?

#Speaker:Elise
Com certeza! Eu faço cesta no cinema!
-> myNameIsWrongDialogue

== myNameIsWrongTaylor ==
#Speaker:Elise
Meu nome é Taylor Swift

#Speaker:Professora
Taylor Swift... Sei, esse é seu nome né?

#Speaker:Elise
Precisamente, professora!

#Speaker:Professora
Você é uma cantora então?

#Speaker:Elise
Com certeza! Eu faço cesta no Spotify!
-> myNameIsWrongDialogue

== myNameIsWrongDialogue ==

#Speaker:Professora
Isso é alguma piada? Saiba que não tem graça, mocinha.

#Color:Green
Olha lá, se achando a famosa hahaha \n Olha lá a "zé ninguém" se achando a famosa hahahahaha

#Speaker:Professora
Tem certeza que sua cabeça está no lugar?

#Speaker:Elise
Não... Digo, sim! Era só uma brincadeira, professora, me desculpe...

#Speaker:Elise
#Color:Blue
(Péssima idéia, por quê eu fui falar isso?)

#Speaker:Professora
Bem, poderia, desta vez, dizer quem é você de verdade?

-> whatIsYourName

== myNameIsRight ==
#Speaker:Elise
É Elise Watson, professora.

#Speaker:Professora
Ah, sim, você não interage muito durante as aulas, por isso não me lembrava de você.

#Speaker:Professora
Você tem boas notas! Poderia até entrar no top 3, mas é uma pena que não chegue perto de Dexter e Howard.

#Speaker:Elise
#Color:Blue
(... Eita...)

#Speaker:Professora
Já que você tinha se prontificado, quero que você analise a história.

#Speaker:Professora
Howard, nos conte então o que você viu.

#Speaker:Howard
Óbvio. Foi assim que aconteceu...

#Action:testimony-transit
#Testimony:in
((empty))

#Color:Green
Testemunho: O que eu vi

#Speaker:Howard
#Color:Green
Obviamente que eu e Dexter estávamos no terraço no intervalo. Sempre almoçamos lá.

#Speaker:Howard
#Color:Green
Foi quando Jack apareceu e disse que os professores estavam chamando Dexter. Assim que Dexter desceu, Jack não tardou e desceu também.

#Speaker:Howard
#Color:Green
Terminei meu almoço e decidi passar na sala de aula para pegar umas coisas.

#Speaker:Howard
#Color:Green
Foi quando eu estava no corredor e vi a porta da sala aberta.

#Speaker:Howard
#Color:Green
Olhei dentro e vi Jack pegando o gameboy da mochila de Dexter!

#Action:testimony-transit
#Testimony:out
((empty))

#Speaker:Professora
Hmm, entendo

#Speaker:Elise
#Color:Blue
(A princípio não vejo nada de errado, mas...Algo me soa estranho, só não sei dizer o que é.)

#Speaker:Professora
Temos aqui a lista de pessoas que tiveram acesso à chave da sala durante o intervalo.

#Action:show-item
#Item:case-1-key-access-list
((empty))

#Speaker:Professora
Temos também o gameboy, que foi encontrado na mochila de Jack.

#Action:show-item
#Item:case-1-gameboy
((empty))

#Speaker:Professora
Elise, caso você queira analisar os objetos de perto, basta checar eles no seu inventário.

#Color:Green
(Para acessar o inventário, basta clicar no ícone de inventário)

#Speaker:Elise
Entendido professora!

#Speaker:Professora
Elise, agora você pode começar o confronto das provas. Está pronta?

#Speaker:Elise
#Color:Blue
<i>(Bem, num confronto eu posso analisar com calma cada frase, avançando e voltando enquanto comparo com as provas no inventário...)</i>

#Speaker:Elise
#Color:Blue
<i>(Acho que eu consigo.)</i>

#Color:Green
(Durante uma avaliação de testemunho, você poderá navegar entre todas as frases que o compõe.)

#Color:Green
(Compare todas as frases do testemunho com os itens em seu inventário para encontrar inconsistências.)

#Color:Green
(Ao encontrar uma inconsistência, apresente o item em questão como objeção ao testemunho para encurralar a testemunha!)

#Speaker:Elise
Ok... Vamos começar então!

#Speaker:Elise
#Color:Blue
(Tenho certeza que algo não se encaixa nessa história, é melhor eu prestar bem atenção nos itens que estão comigo)

//CROSS EXAMINATION CASO 1

#Action:cross-exam
((empty))

#Color:Green
Testemunho: O que eu vi
-> case1CrossExam1Phrase1

== case1CrossExam1Phrase1 ==
#Speaker:Howard
#OptionMode:cross-exam
Obviamente que eu e Dexter estávamos no terraço no intervalo. Sempre almoçamos lá.
~crossExamReturn = ->case1CrossExam1Phrase1
->case1CrossExam1Choice1

== case1CrossExam1Choice1 ==
+ [Pressionar] -> case1CrossExam1Choice1.press 
+ [cross-next]  -> case1CrossExam1Phrase2
+ [Apresentar:case-1-gameboy] -> crossExamErrorMain
+ [Apresentar:case-1-key-access-list] -> crossExamErrorMain

= press
#Action:press
#Press:young-elise
((empty))

#Speaker:Elise
Sempre? Vocês nunca almoçam em outro lugar?

#Speaker:Howeard
Óbvio que não! Lá é o lugar mais tranquilo. No pátio é a maior baderna.

#Speaker:Elise
E vocês almoçam sozinhos lá?

#Speaker:Howard
Claro que sim! Nunca que iríamos almoçar com a ralé.

#Speaker:Howard
Mas continuando…

#Speaker:Professora
Certo, vocês estavam almoçando, o que aconteceu?
-> case1CrossExam1Phrase2

== case1CrossExam1Phrase2 ==
#Speaker:Howard
#OptionMode:cross-exam
Foi quando Jack apareceu e disse que os professores estavam chamando Dexter.
~crossExamReturn = ->case1CrossExam1Phrase2
->case1CrossExam1Choice2

== case1CrossExam1Choice2 ==
+ [Pressionar] -> case1CrossExam1Choice2.press
+ [cross-previous] -> case1CrossExam1Phrase1
+ [cross-next]  -> case1CrossExam1Phrase3
+ [Apresentar:case-1-gameboy] -> crossExamErrorMain
+ [Apresentar:case-1-key-access-list] -> crossExamErrorMain

= press
#Action:press
#Press:young-elise
((empty))

#Speaker:Elise
Por que os professores chamaram o Dexter?

#Speaker:Howard
Ah, era algo sobre as notas excepcionais de Dexter.

#Speaker:Howard
É óbvia a possibilidade dele representar a escola em futuras competições.

#Speaker:Elise
#Color:Blue
(É, a professora tinha dito que as notas dele era a mais alta da sala ou algo assim...)

#Speaker:Howard
Continuando...
->case1CrossExam1Phrase3
    
== case1CrossExam1Phrase3 ==
#Speaker:Howard
#OptionMode:cross-exam
Assim que Dexter desceu, Jack não tardou e desceu também.
~crossExamReturn = ->case1CrossExam1Phrase3
->case1CrossExam1Choice3

== case1CrossExam1Choice3 ==
+ [Pressionar] -> case1CrossExam1Choice3.press 
+ [cross-previous] -> case1CrossExam1Phrase2
+ [cross-next]  -> case1CrossExam1Phrase4
+ [Apresentar:case-1-gameboy] -> crossExamErrorMain
+ [Apresentar:case-1-key-access-list] -> crossExamErrorMain

= press
#Action: press
#Press: young-elise
((empty))

#Speaker:Elise
Jack foi atrás do Dexter?

#Speaker:Howard
Óbvio que eu não sei!

#Speaker:Howard
Talvez sim, talvez não. Ele não foi tão rápido atrás do Dexter.

#Speaker:Elise
Como assim não foi tão rápido?

#Speaker:Professora
Acho que ele está querendo dizer que ele não saiu correndo, como se estivesse indo atrás?

#Speaker:Howard
Sim, ele só saiu de forma natural.

#Speaker:Elise
E o que você fez?
-> case1CrossExam1Phrase4

== case1CrossExam1Phrase4 ==
#Speaker:Howard
#OptionMode:cross-exam
Terminei meu almoço e decidi passar na sala de aula para pegar umas coisas.
~crossExamReturn = ->case1CrossExam1Phrase4
-> case1CrossExam1Choice4

== case1CrossExam1Choice4 ==
+ [Pressionar] -> case1CrossExam1Choice4.press 
+ [cross-previous] -> case1CrossExam1Phrase3
+ [cross-next]  -> case1CrossExam1Phrase5
+ [Apresentar:case-1-gameboy] -> crossExamErrorMain
+ [Apresentar:case-1-key-access-list] -> crossExamErrorMain

= press
#Action:press
#Press:young-elise
((empty))

#Speaker:Elise
Que coisas você decidiu pegar?

#Speaker:Howard
Isso é realmente importante? Não é esse o foco aqui.

#Speaker:Professora
Elise, se abstenha de fazer perguntas se elas não forem relevantes.

#Speaker:Elise
Certo…

#Color:Blue
(É, realmente, se ele estiver falando a verdade, óbvio que não faz diferença, né?)

#Speaker:Howard    
Mas então...
->case1CrossExam1Phrase5

== case1CrossExam1Phrase5 ==
#Speaker:Howard
#OptionMode:cross-exam
Foi quando eu estava no corredor e vi a porta da sala aberta.
~crossExamReturn = ->case1CrossExam1Phrase5
-> case1CrossExam1Choice5

== case1CrossExam1Choice5 ==
+ [Pressionar] -> case1CrossExam1Choice5.press 
+ [cross-previous] -> case1CrossExam1Phrase4
+ [cross-next]  -> case1CrossExam1Phrase6
+ [Apresentar:case-1-gameboy] -> crossExamErrorMain
+ [Apresentar:case-1-key-access-list] -> case1CrossExam1ChoiceRight

= press
#Action: press
#Press: young-elise
((empty))

#Speaker:Elise
Então você está dizendo que ela estava aberta antes de você chegar?

#Speaker:Howard
Sim, oras. Também fiquei surpreso, eu estava a caminho de ir pegar a chave.

#Speaker:Elise
Então você não chegou a pegar a chave?

#Speaker:Howard
E precisa? Se eu passei na frente da porta e ela estava aberta, é óbvio que eu não fui pegar a chave!

#Speaker:Elise
#Color:Blue
(Hmm… Então ele não passou para pegar a chave da sala?)

#Speaker:Elise
Tá, você passou pela sala e fez o que?
->case1CrossExam1Phrase6    

== case1CrossExam1Phrase6 ==
#Speaker:Howard
#OptionMode:cross-exam
Olhei dentro e vi Jack pegando o gameboy da mochila de Dexter!
~crossExamReturn = ->case1CrossExam1Phrase6
-> case1CrossExam1Choice6

== case1CrossExam1Choice6 ==
+ [Pressionar] -> case1CrossExam1Choice6.press 
+ [cross-previous] -> case1CrossExam1Phrase5
+ [cross-finish]  -> case1CrossExam1Conclusion
+ [Apresentar:case-1-gameboy] -> crossExamErrorMain
+ [Apresentar:case-1-key-access-list] -> crossExamErrorMain

= press
#Action:press
#Press:young-elise
((empty))

#Speaker:Elise
Tem certeza que era a mochila do Dexter?

#Speaker:Howard
Óbvio que tenho, ele senta na minha frente.

#Speaker:Howard
Seria incomum não reconhecer as coisas de um amigo, certo?

#Speaker:Elise
Amigo… Sei…

#Speaker:Howard    
Está duvidando de nossa amizade?

#Speaker:Elise
Ah, nada não, só estava pensando alto, deixa para lá.
->case1CrossExam1Conclusion

== case1CrossExam1Conclusion ==
#Speaker:Elise
#Color:Blue
(Essa história é muito conveniente. Tem algo muito estranho nas palavras dele e eu preciso saber o que é!)

#Speaker:Elise
#Color:Blue
(É melhor eu dar uma olhada no inventário e comparar com o que está falando, ele tem que estar mentindo!)
->case1CrossExam1Phrase1 

== case1CrossExam1ChoiceRight ==
#Action:present
#Present:young-elise
((empty))

#Speaker:Elise
Ora, mas é mesmo?

#Speaker:Howard
Como assim?

#Speaker:Elise
A porta estava aberta quando você passou na frente. É isso?

#Speaker:Howard
Óbvio! Você não me ouviu?

#Speaker:Elise
Ah, eu ouvi sim! Recebi a bola aqui sim.

#Speaker:Elise
Mas me parece que isso aqui diz outra coisa!

#Action:show-item
#Item:case-1-key-access-list
((empty))

#Speaker:Howard
Mas o que?!

#Speaker:Elise
Aqui na lista diz que após Dexter pegar e devolver a chave, foi você quem a pegou para ir até a sala!

#Speaker:Elise
Em outras palavras, quando você passou na frente da sala...

#Speaker:Elise
Como ela poderia estar aberta sendo que foi você quem pegou com a chave?!

#Speaker:Professora
Realmente. Ou Dexter estaria na sala ou não teria como ela estar aberta.

#Speaker:Howard
Óbvio que… Que…

#Speaker:Howard
Ah! Eu estou um pouco nervoso. Não é do meu feitio relatar esse tipo de coisa.

#Speaker:Howard
Deixe-me reorganizar os pensamentos e contar novamente.

#Speaker:Professora
Ok, mas tente contar exatamente como aconteceu desta vez.
->END


