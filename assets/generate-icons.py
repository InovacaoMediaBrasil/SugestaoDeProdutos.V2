"""
Generate the project icon assets from assets/logo.png (black line glyph, transparent bg).

Usage: python assets/generate-icons.py
Requires Pillow and the Inter font (Inter-Bold.otf / Inter-Medium.otf) for the social preview.
"""
import sys
from pathlib import Path
from PIL import Image, ImageDraw, ImageFont

repo = Path(sys.argv[1]) if len(sys.argv) > 1 else Path(__file__).resolve().parent.parent
src = Image.open(repo / "assets" / "logo.png").convert("RGBA")
out = repo / "assets"
out.mkdir(exist_ok=True)

TOP = (14, 116, 144)      # teal-700
BOTTOM = (8, 51, 68)      # teal-950-ish
S = 1024                  # master size (2x of 512 for clean downsampling)


def gradient(w, h):
    g = Image.new("RGBA", (w, h))
    px = g.load()
    for y in range(h):
        for x in range(w):
            t = (x / w * 0.35) + (y / h * 0.65)
            px[x, y] = tuple(int(TOP[i] + (BOTTOM[i] - TOP[i]) * t) for i in range(3)) + (255,)
    return g


def white_glyph(size):
    glyph = src.resize((size, size), Image.LANCZOS)
    # Base logo carries a faint diagonal hatch at alpha <= 15; drop it and rescale the rest.
    alpha = glyph.getchannel("A").point(lambda a: 0 if a <= 16 else min(255, (a - 16) * 255 // 239))
    white = Image.new("RGBA", glyph.size, (255, 255, 255, 255))
    white.putalpha(alpha)
    return white


def rounded_mask(w, h, r):
    m = Image.new("L", (w, h), 0)
    ImageDraw.Draw(m).rounded_rectangle((0, 0, w - 1, h - 1), radius=r, fill=255)
    return m


# --- Master icon: rounded tile + white glyph ---
tile = gradient(S, S)
glyph_size = int(S * 0.70)
off = (S - glyph_size) // 2
tile.alpha_composite(white_glyph(glyph_size), (off, off))
icon = Image.new("RGBA", (S, S), (0, 0, 0, 0))
icon.paste(tile, (0, 0), rounded_mask(S, S, int(S * 0.22)))

for size in (256, 128, 64, 32):
    icon.resize((size, size), Image.LANCZOS).save(out / f"project-icon-{size}.png", optimize=True)
icon.resize((512, 512), Image.LANCZOS).save(out / "project-icon.png", optimize=True)
icon.save(out / "favicon.ico", sizes=[(16, 16), (32, 32), (48, 48), (64, 64)])

# --- Social preview (GitHub recommends 1280x640) ---
W, H = 1280, 640
social = gradient(W, H)
d = ImageDraw.Draw(social)
ic = 360
social.alpha_composite(white_glyph(ic), (110, (H - ic) // 2))
title = ImageFont.truetype("/usr/share/fonts/opentype/inter/Inter-Bold.otf", 76)
sub = ImageFont.truetype("/usr/share/fonts/opentype/inter/Inter-Medium.otf", 34)
x = 540
d.text((x, 215), "Sugestão de", font=title, fill="white")
d.text((x, 300), "Produtos V2", font=title, fill="white")
d.text((x, 410), "Product suggestions API", font=sub, fill=(186, 230, 253))
social.convert("RGB").save(out / "social-preview.png", optimize=True)
print("done")
