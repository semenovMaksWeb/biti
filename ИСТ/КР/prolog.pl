agelimit(sport, not).
agelimit(fantastic, not). 
agelimit(drama, not).
agelimit(historical, not). 
agelimit(horror, yes). 
agelimit(fighters, yes). 
agelimit(western, yes). 
gender(sport, man). 
gender(fantastic, man).
gender(historical, woman). 
gender(drama, woman). 
theme(sport, sport). 
theme(drama, sensation). 
theme(horror, horror). 
theme(fighters, fighters). 
theme(western, cowboys).

?- agelimit(X, not) -> write('поиск жанров без возрастных ограничении '), write(X), nl .
?- agelimit(X, not),  gender(X, man) -> write('поиск жанров без возрастных ограничении для мужщин '), write(X) , nl .