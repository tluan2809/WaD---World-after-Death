import pygame
import random
import math

from pygame import mixer

pygame.init()
screen = pygame.display.set_mode((800, 600))

#title and icon
pygame.display.set_caption('planet shoter')
icon = pygame.image.load('logo.png')
pygame.display.set_icon(icon)

#background
background = pygame.image.load('back.png')

#background sound
mixer.music.load('background.wav')
mixer.music.play(-1)

#player
playerimg = pygame.image.load('ship.png')
playerx = 370
playery = 480
changex = 0
changey = 0

#enemy
enemyimg = []
enemyx = []
enemyy = []
echangex = []
echangey = []
num_enemy = 10
for i in range(num_enemy):
    enemyimg.append(pygame.image.load('rock.png'))
    enemyx.append(random.randint(0, 767))
    enemyy.append(random.randint(50, 300))
    echangex.append(2)
    echangey.append(10)
    e = enemyx[i]
    e1 = enemyy[i]

#e_bullet
E_bullet = pygame.image.load('e_bullet.png')
e_x = enemyx
e_y = enemyy
e_change_x = 0
e_change_y = 0

#bullet
bulletimg = pygame.image.load('bullet.png')
bulletx = 0
bullety = 480
bchangex = 4
bchangey = 5
#ready is you cant see bullet, fire is you can see bullet
b_shoot = 'ready'
E_shoot = 'ready'

#score
s_value = 0
font = pygame.font.Font('freesansbold.ttf', 30)
textx = 10
texty = 10

#game over
f_over = pygame.font.Font('freesansbold.ttf', 70)

def player(x, y):
    screen.blit(playerimg, (x, y))

def enemy(x, y, i):
    screen.blit(enemyimg[i], (x ,y))

def fire_e_bullet(x, y):
    global E_shoot
    E_shoot = 'fire'
    screen.blit(E_bullet, (x + 14 , y + 5))
    
def e_bullet_collision(e_x, e_y, playerx, playery):
    shoot = math.sqrt((math.pow(e_x - playerx, 2)) + (math.pow(e_y - playery, 2)))
    if shoot < 27:
        return True
    else:
        return False
    
def fire_bullet(x ,y):
    global b_shoot
    b_shoot = 'fire'
    screen.blit(bulletimg, (x + 19, y + 5))
    
def showscore(x ,y):
    score = font.render('Score: '+ str(s_value), True, (255, 255, 255))
    screen.blit(score, (x, y))

def game_over(x, y):
    t_over = f_over.render('GAME OVER', True, (255, 0, 0))
    screen.blit(t_over, (200, 250))

#va chạm
def iscollision(enemyx, enemyy, bulletx, bullety):
    distance = math.sqrt((math.pow(enemyx - bulletx, 2)) + (math.pow(enemyy - bullety, 2)))
    if distance < 27:
        return True
    else:
        return False
    

#game loop
run = True
while run:

    #set img to background
    screen.blit(background, (0, 0))
    
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            run = False 

        #control
        if event.type == pygame.KEYDOWN:
            if event.key == pygame.K_LEFT:
                changex -= 2
            if event.key == pygame.K_RIGHT:
                changex += 2
            if event.key == pygame.K_UP:
                changey -= 2
            if event.key == pygame.K_DOWN:
                changey += 2
            if event.key == pygame.K_SPACE:
                if b_shoot is 'ready':
                    b_sound = mixer.Sound('laser.wav')
                    b_sound.play()
                    bulletx = playerx
                    bullety = playery
                    fire_bullet(bulletx , bullety)
                
        if event.type == pygame.KEYUP:
            if event.key == pygame.K_LEFT or event.key == pygame.K_RIGHT or event.key == pygame.K_UP or event.key == pygame.K_DOWN:
                changex = 0
                changey = 0
        
    playerx += changex
    playery += changey
    
    #create boundary
    if playerx <= 0:
        playerx = 0
    elif playerx >= 736:
        playerx = 736
    if playery <= 0:
        playery = 0
    elif playery >= 536:
        playery = 536

    #enemy move
    for i in range(num_enemy):

        e_bullet_collision(e_x, e_y, playerx, playery)

        #game over
        if enemyy[i] > 440:
            for j in range(num_enemy):
                enemyy[j] = 2000
            game_over(200, 250)
            break
            
        enemyx[i] += echangex[i]    
        if enemyx[i] <= 0:
            echangex[i] += 4
            enemyy[i] += echangey[i]
            enemyx[i] = 0
        elif enemyx[i] >= 768:
            echangex[i] -= 4
            enemyy[i] += echangey[i]
            enemyx[i] = 768
        if enemyy[i] <= 50:
            enemyy[i] = 50
        #va chạm
        collision = iscollision(enemyx[i], enemyy[i], bulletx, bullety)
        if collision:
            explo_sound = mixer.Sound('explosion.wav')
            explo_sound.play()
            bullety = 480
            b_shoot = 'ready'
            s_value += 1
            print('Your score :',s_value)
            enemyx[i] = random.randint(0, 767)
            enemyy[i] = random.randint(50, 300)
        enemy(enemyx[i], enemyy[i], i)
        e_1[i] = enemyx[i]
        e_2[i] = enemyy[i]
        if e_1[i] != e and e_2[i] != e1:
            fire_e_bullet(e_1, e_2 + 2)
 
    #bullet move
    if bullety <= 0:
        bullety = 480
        b_shoot = 'ready'
    if b_shoot is 'fire':
        fire_bullet(bulletx, bullety)
        bullety -= bchangey

    player(playerx, playery)
    showscore(textx, texty)
    pygame.display.update()
 
