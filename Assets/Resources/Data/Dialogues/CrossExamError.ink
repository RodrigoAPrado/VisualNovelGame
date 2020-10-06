VAR hitPoints = 5
VAR crossExamReturn = ""
VAR crossExamErrorLastPhrase = 0

== crossExamErrorMain ==
#Present:YoungElise
((empty))

~temp errorPhrase = RANDOM(1, 4)
{ errorPhrase == crossExamErrorLastPhrase:
        ->crossExamErrorMain
}
~ crossExamErrorLastPhrase = errorPhrase
{ errorPhrase:
    -1: ->crossExamError1 
    -2: ->crossExamError2
    -3: ->crossExamError3
    -4: ->crossExamError4
}

== crossExamError1 ==
#Speaker:Elise
Ora, mas é mesmo?

#Speaker:Howard
É... Óbvio.

#Speaker:Elise
Tem certeza? Eu acho que... Er...

#Speaker:Professora
Elise, você acha que tem algo errado com o que ele disse?

#Speaker:Elise
Talvez?

#Speaker:Professora
#Anim:hitpoint-reduce
Se você não tiver certeza não interrompa.

~hitPoints--

{ hitPoints <= 0:
    -> gameOver
}
#Speaker:Elise
#Color:Blue
(Droga, marquei bobeira...)

#Speaker:Howard
Bem, continuando...
-> crossExamReturn

== crossExamError2 ==
#Speaker:Elise
Ora, mas é mesmo?

#Speaker:Howard
É... Óbvio.

#Speaker:Professora
Elise, qual o problema?

#Speaker:Elise
Não, é que eu... Eu pensei que... É, acho que nada;

#Speaker:Professora
#Anim:hitpoint-reduce
Desse jeito não posso continuar com sua análise, esteja mais atenta.

~hitPoints--

{ hitPoints <= 0:
    -> gameOver
}

#Speaker:Elise
#Color:Blue
(Droga, preciso acertar no rebote...)
-> crossExamReturn

== crossExamError3 ==
#Speaker:Elise
Ora, mas é mesmo?

#Speaker:Howard:
É, não ouviu o que eu falei?.

#Speaker:Elise
Claro, mas é que isso aqui prova o erro ali na...

#Speaker:Professora
Na... ?

#Speaker:Elise
Na... Nada, eu devo ter me confundido.

#Speaker:Professora
#Anim:hitpoint-reduce
Na... Na verdade eu acho que você está é enrolando, mocinha.

~hitPoints--

{ hitPoints <= 0:
    -> gameOver
}

#Speaker:Elise
#Color:Blue
(Gulp! Na... Na mão do jogador adversário...)

#Speaker:Howard
Na... Na sua posição eu desistiria, é óbvio.
-> crossExamReturn

== crossExamError4 ==
#Speaker:Elise
Ora, mas é mesmo?

#Speaker:Professora
Hmm? Achou algo de errado Elise?

#Speaker:Elise
Essa prova aqui contradiz o que está sendo dito!

#Speaker:Professora
É mesmo? E contradiz como, pode nos explicar?

#Speaker:Elise
Bem...

#Speaker:Professora
...

#Speaker:Elise
Não contradiz né?

#Speaker:Howard
É óbvio que não!

#Speaker:Professora
#Anim:hitpoint-reduce
Elise, por favor pense na explicação antes de acusar algo da próxima vez.

~hitPoints--

{ hitPoints <= 0:
    -> gameOver
}

#Speaker:Elise
#Color:Blue
(Argh! Eu quase consegui!)

-> crossExamReturn

== gameOver ==
#Speaker:Professora
Bem, acho que ouvimos o suficiente.

#Speaker:Elise
Mas, Professora, eu ainda não-

#Speaker:Professora

#Speaker:Professora
Silêncio!

#Speaker:Professora
Para mim já está claro, Jack roubou o gameboy de Dexter, não há mais dúvidas.

#Speaker:Professora
Infelizmente, Elise, não acho que você esteja contribuindo.

#Speaker:Professora
É melhor afiar seus argumentos antes de se prontificar deste jeito para não passar vergonha.

#Speaker:Professora
Enfim, Jack, venha comigo para a diretoria.

#Speaker:Howard
Haha, mas é óbvio que iria acabar assim, não é mesmo?

#Action:game-over
((gameOver))
->END




