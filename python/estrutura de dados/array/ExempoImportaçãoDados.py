# -*- coding: utf-8 -*-
"""
Created on Fri Apr 24 11:22:48 2020

@author: luisc
"""
import pandas as pd
resumo_aluno = pd.read_csv('C:\\Users\\luisc\\Documents\\GitHub\\aulas-graduacao\\Analise de dados\\datasets\\csv\\resumoAlunos.csv')

#media_alunos = resumo_aluno['av1']

print(resumo_aluno.describe())