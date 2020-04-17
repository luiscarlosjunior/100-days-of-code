# -*- coding: utf-8 -*-
"""
Created on Fri Apr 17 12:43:41 2020
Escreva uma função rotate (ar [], d, n) que gere arr [] do 
tamanho n pelos elementos d.
@author: luisc
"""
# Função para rotacionar o arr[] de tamanho d
def leftRotate(arr, d, n):
    for i in range(d):
        leftRotateByOne(arr, n)
        
def leftRotateByOne(arr, n):
    temp = arr[0]
    for i in range(n-1):
        arr[i] = arr[i + 1]
    arr[n - 1] = temp

def printArray(arr, size):
    for i in range(size):
        print(arr[i], end = ' ')
        
arr = [1, 2, 3, 4, 5, 6, 7]
leftRotate(arr, 6, 7)
printArray(arr, 7)