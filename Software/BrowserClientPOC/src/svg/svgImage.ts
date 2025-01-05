import { SvgElement } from "./svgElement";
import { SvgElementType } from "./svgElementType";

export class SvgImage {
    width: number;
    height: number;
    textFont: string | "Arial";
    elements: SvgElement[];

    constructor(w: number, h: number) {
        this.width = w;
        this.height = h;

        this.elements = [];
    }

    addCircle(x: number, y: number, r: number, fill?: string | null, stroke?: string | null, strokeWidth?: number | null) {
        let element = new SvgElement();
        element.elementType = SvgElementType.Circle;
        element.x = x;
        element.y = y;
        element.r = r;
        if (fill) {
            element.fill = fill;
        }

        if (stroke) {
            element.stroke = stroke;
        }
        if (strokeWidth) {
            element.strokeWidth = strokeWidth;
        }
        this.elements.push(element);
    }

    addLine(x: number, y: number, x2: number, y2: number, fill?: string | null, stroke?: string | null, strokeWidth?: number | null) {
        let element = new SvgElement();
        element.elementType = SvgElementType.Line;
        element.x = x;
        element.y = y;
        element.x2 = x2;
        element.y2 = y2;
        if (fill) {
            element.fill = fill;
        }
        if (stroke) {
            element.stroke = stroke;
        }
        if (strokeWidth) {
            element.strokeWidth = strokeWidth;
        }
        this.elements.push(element);
    }

    addRectangle(x: number, y: number, width: number, height: number, fill?: string | null) {
        let element = new SvgElement();
        element.elementType = SvgElementType.Rectangle;
        element.x = x;
        element.y = y;
        element.width = width;
        element.height = height;
        if (fill) {
            element.fill = fill;
        }
        this.elements.push(element);
    }

    addText(x: number, y: number, text: string, fontSize: number, fill?: string | null, fontWeight?: string | null) {

        let element = new SvgElement();
        element.elementType = SvgElementType.Text;
        element.x = x;
        element.y = y;
        element.text = text;
        element.fontSize = fontSize;
        if (fontWeight) {
            element.fontWeight = fontWeight;
        }
        if (fill) {
            element.fill = fill;
        }
        this.elements.push(element);
    }

    toString(): string {

        let svg = `<svg viewBox="0 0 ${this.width} ${this.height}" xmlns="http://www.w3.org/2000/svg">`;

        if (this.textFont) {
            svg += `<style>
            text {
                font-family: ${this.textFont};
            }
            </style>`;
        }

        for (let element of this.elements) {
            switch (element.elementType) {
                case SvgElementType.Rectangle:
                    svg += `<rect x="${element.x}" y="${element.y}" width="${element.width}" height="${element.height}"`;
                    if (element.fill) {
                        svg += ` fill="${element.fill}"`;
                    }
                    svg += ` />`;
                    break;
                case SvgElementType.Circle:
                    svg += `<circle cx="${element.x}" cy="${element.y}" r="${element.r}"`;
                    if (element.fill) {
                        svg += ` fill="${element.fill}"`;
                    }
                    if (element.stroke) {
                        svg += ` stroke="${element.stroke}"`;
                    }
                    if (element.strokeWidth) {
                        svg += ` stroke-width="${element.strokeWidth}"`;
                    }
                    svg += ` />`;
                    break;
                case SvgElementType.Text:
                    svg += `<text x="${element.x}" y="${element.y}" font-family="${this.textFont}" `;
                    if (element.fill) {
                        svg += ` fill="${element.fill}"`;
                    }
                    if (element.fontWeight) {
                        svg += ` font-weight="${element.fontWeight}"`;
                    }
                    if (element.fontSize) {
                        svg += ` font-size="${element.fontSize}"`;
                    }
                    svg += `>${element.text}</text> />`;

                    break;
                case SvgElementType.Line:
                    svg += `<line x1="${element.x}" y1="${element.y}" x2="${element.x2}" y2="${element.y2}"`;
                    if (element.fill) {
                        svg += ` fill="${element.fill}"`;
                    }
                    if (element.stroke) {
                        svg += ` stroke="${element.stroke}"`;
                    }
                    if (element.strokeWidth) {
                        svg += ` stroke-width="${element.strokeWidth}"`;
                    }
                    svg += ` />`;
            }
        }

        svg += `</svg>`;
        return svg;
    }


}