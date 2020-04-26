# -*- coding: utf-8 -*-
"""
Created on Fri Apr 24 10:04:30 2020

@author: luisc
"""
#x = 'Estou aqui'

try:
    print(p)
except NameError:
    print('Ops, deu um erro de variável não inicializada')
except:
    print('Outro tipo de erro')
finally:
    print('Estou sempre aqui')



# Raise - lança uma exceção para o usuário
"""
valor = -10

if valor < 0:
    raise Exception('O valor é negativo')
"""