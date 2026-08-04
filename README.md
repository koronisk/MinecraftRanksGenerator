# MinecraftRanksGenerator
Генерация пиксельных hoplite like рангов для майнкрафт ресурспаков.

<img width="184" height="72" alt="Example" src="https://github.com/user-attachments/assets/0ea5b500-8608-4dd7-9c92-849630f8de04" /> </br>
*Пример готового изображения*

## Как использовать?

### Заполните данные
Введите нужные ранги в `tasks.json`.</br>
Для примера возьмём сложности уровней из плагина [ParkourBeat](https://github.com/XaviersDev/ParkourBeat-Modern).
```json
[
    {
        "text": "лёгкий",
        "bg": "#19e337"
    },
    {
        "text": "сложный",
        "bg": "#ffbe1b"
    },
    {
        "text": "эксперт",
        "bg": "#ff1d1b"
    },
    {
        "text": "эксперт+",
        "bg": "#9c1bff"
    }
]
```

### Запустите приложение
```sh
$ dotnet run
```

### Результат
Готовое изображение можно найти в `output/merged.png`:

<img width="260" height="190" alt="Результат" src="https://github.com/user-attachments/assets/71f94d29-b639-4f74-870d-9f5e91d53926" /> </br>

*Каждый ранг так же отдельно экспортируется в `output/ranks`*

# Символы

<img width="414" height="414" alt="Image" src="https://github.com/user-attachments/assets/adac4049-bf59-4fef-a285-d0fdd1f8bd64" /> </br>

Большинство символов имеют размер `5x5` пикселей.

### Исключения:
Буквы **Ё** и **Й**: `5x7` (дополнительная высота)</br>
Пробел: `1x5`

# Свои символы

Вы можете загрузить свои символы просто добавив изображения в `assets/custom`. </br>
Называйте файлы в таком формате: `{символ}.png`.

Длина символа никак не ограничена.</br>
Рекомендуемая высота: `5` или `7`.

Пустое пространство обозначьте цветом `#ffffff`, сам символ цветом `#000000`.

## Пример

### Создадим файл
`assets/custom/?.png`

<img width="50" height="50" alt="Свой символ" src="https://github.com/user-attachments/assets/7f567249-4cac-4b0b-80aa-24666d19d870" /> </br>

### Создадим ранг
`tasks.json`

```json
[
    {
        "text": "текст?",
        "bg": "#2fc4c9"
    }
]
```

### Результат
`output/merged.png`

<img width="320" height="56" alt="Результат" src="https://github.com/user-attachments/assets/14ab9c95-bcfa-4f61-95df-8ea846622468" />