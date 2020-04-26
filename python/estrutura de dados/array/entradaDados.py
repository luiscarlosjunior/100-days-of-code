# -*- coding: utf-8 -*-
"""
Created on Fri Apr 24 08:37:53 2020

@author: luisc
"""
import pandas as pd
import numpy as np

data = np.array([1,2,3,4, 15])
data_set = pd.read_csv('C:/Users/luisc/Documents/GitHub/aulas-graduacao/Analise de dados/datasets/csv/resumoAlunos.csv')
s = pd.Series(data)
ss = pd.Series(1, 2, 3, 4, 5, 6)

print(ss)

