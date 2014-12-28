Vector2D = Struct.new(:x, :y) {
	def z; 0; end
	def to_a; [x, y, 0]; end
}
Vector3D = Struct.new(:x, :y, :z) {
	def to_a; [x, y, z]; end
}

class Array
	
	def to_vector3D()
		Vector3D.new(*self[0..2])
	end
	
	def to_vector2D()
		Vector2D.new(*self[0..1])
	end
	
	def distribute(times=nil) # &block
		raise ParameterTypeException, "Integer or NilClass expected for optional Parameter `times'" if not times.is_a?(Integer) || times.nil?
		raise BlockMissingException, "Block expected" if not block_given?
		if not times.nil?
			times.times { |i|
				break if yield(self[i % self.size])
			}
		else
			i = 0
			loop do
				break if yield(self[i])
				i = (i + 1) % self.size
			end
		end
	end
	
	def dist
		@dist_index = @dist_index ? ((@dist_index + 1) % self.size) : 1
		self[@dist_index-1]
	end
	
	def reset_dist()
		@dist_index = 0
	end
	
end

module Converts
	
	def self.a_to_ass(alpha)
		raise ParameterTypeException, "Integer expected" if not alpha.is_a? Integer
		alpha = Math.trim(alpha, 0, 255)
		sprintf("&H%02X&", 255 - alpha)
	end
	
	def self.ass_to_a(ass_alpha)
		raise ParameterTypeException, "String expected" if not ass_alpha.is_a? String
		raise ParameterFormatException, "ASS Alpha Value expected" if not ass_alpha =~ /\&H([0-9a-fA-F]{2})\&/
		$1.to_i(16)
	end
	
	def self.rgb_to_ass(r, g, b)
		raise ParameterTypeException, "Integer expected for `r'" if not r.is_a? Integer
		raise ParameterTypeException, "Integer expected for `g'" if not g.is_a? Integer
		raise ParameterTypeException, "Integer expected for `b'" if not b.is_a? Integer
		r, g, b = Math.trim(r, 0, 255), Math.trim(g, 0, 255), Math.trim(b, 0, 255)
		sprintf("&H%02X%02X%02X&", b, g, r)
	end
	
	def self.ass_to_rgb(ass_color)
		raise ParameterTypeException, "String expected" if not ass_color.is_a? String
		raise ParameterFormatException, "ASS Color Value expected" if not ass_color =~ /\&H([0-9a-fA-F]{2})([0-9a-fA-F]{2})([0-9a-fA-F]{2})\&/
		return $3.to_i(16), $2.to_i(16), $1.to_i(16)
	end
	
	def self.shape_to_pixels(shape)
		raise NotImplementedError
	end
	
	def self.text_to_shape(text, style)
		raise NotImplementedError
	end
	
	def self.image_to_pixels(image)
		raise NotImplementedError
	end
	
end

module Math
	
	def self.deg(value)
		raise ParameterTypeException, "Numeric expected" if not value.is_a? Numeric
		value / Math::PI * 180
	end
	
	def self.rad(value)
		raise ParameterTypeException, "Numeric expected" if not value.is_a? Numeric
		value * Math::PI / 180
	end
	
	def self.bezier(percent, *points)
		percent = percent.to_f if percent.is_a? Integer
		raise ParameterTypeException, "Float expected" if not percent.is_a? Float
		raise ParameterFormatException, "`Percent' have to between 0 and 1" if not percent.between?(0, 1)
		vectors = points.select { |current| current.is_a?(Vector2D) || current.is_a?(Vector3D) }
		raise ParameterFormatException, "To less points given. Expect minimum two" if vectors.size < 2
		
		# fac! function
		fac = lambda { |n|
			k = 1
			if n > 1
				for i in 2..n
					k *= i
				end
			end
			k
		}
		# binomical function
		bin = lambda { |i, n| fac.call(n) / (fac.call(i) * fac.call(n-i)) }
		# berstein polynom
		bern = lambda { |perc, i, n| bin.call(i, n) * perc**i * (1 - perc)**(n - i) }
		vector = Vector3D.new(0, 0, 0)
		size = vectors.size - 1
		for i in 0...size
			berns = bern.call(percent, i, size)
			vector.x += vectors[i].x.to_f * berns
			vector.y += vectors[i].y.to_f * berns
			vector.z += vectors[i].z.to_f * berns
		end
		vector
	end
	
	def self.distance(width, height, depth=nil)
		raise ParameterTypeException, "Numeric expected for `width'" if not width.is_a? Numeric
		raise ParameterTypeException, "Numeric expected for `height'" if not height.is_a? Numeric
		raise ParameterTypeException, "Numeric or NilClass expected for `depth'" if not depth.is_a?(Numeric) || depth.nil?
		
		depth.nil? ? (width**2 + height**2)**0.5 : (width**2 + height**2 + depth**2)**0.5
	end
	
	def self.degree(vectorA, vectorB)
		raise ParameterTypeException, "Vector3D expected for `vectorA'" if not vectorA.is_a? Vector3D
		raise ParameterTypeException, "Vector3D expected for `vectorB'" if not vectorB.is_a? Vector3D
		degr = self.deg(
			self.acos(
				(vectorA.x * vectorB.x + vectorA.y * vectorB.y + vectorA.z * vectorB.z) /
				(self.distance(vectorA.x, vectorA.y, vectorA.z) * self.distance(vectorB.x, vectorB.y, vectorB.z))
			)
		)
		
		(vectorA.x * vectorB.y - vectorA.y * vectorB.x) < 0 and -degr or degr
	end
	
	def self.ellipse(x, y, width, height, angle)
		raise ParameterTypeException, "Numeric expected for `x'" if not x.is_a? Numeric
		raise ParameterTypeException, "Numeric expected for `y'" if not y.is_a? Numeric
		raise ParameterTypeException, "Numeric expected for `width'" if not width.is_a? Numeric
		raise ParameterTypeException, "Numeric expected for `height'" if not height.is_a? Numeric
		raise ParameterTypeException, "Numeric expected for `angle'" if not angle.is_a? Numeric
		
		ra = self.rad(angle)
		return x + width / 2 * self.sin(ra), y + height / 2 * self.cos(ra)
	end
	
	def self.ortho(vectorA, vectorB)
		raise ParameterTypeException, "Vector3D expected for `vectorA'" if not vectorA.is_a? Vector3D
		raise ParameterTypeException, "Vector3D expected for `vectorB'" if not vectorB.is_a? Vector3D
		
		Vector3D.new(
			vectorA.y * vectorB.z - vectorA.z * vectorB.y,
			vectorA.z * vectorB.x - vectorA.x * vectorB.z,
			vectorA.x * vectorB.y - vectorA.y * vectorB.x
		)
	end
	
	def self.rotate(point, axis, angle)
		raise ParameterTypeException, "Vector3D expected for `point'" if not point.is_a? Vector3D
		raise ParameterTypeException, "Symbol expected for `axis'" if not axis.is_a? Symbol
		raise ParameterTypeException, "Numeric expected for `angle'" if not angle.is_a? Numeric
		raise ParameterFormatException, "`axis' must be one of `:x', `:y' or `:z'" if not [:x, :y, :z].include? axis
		
		ra = self.rad(angle)
		return case axis
			when :x
				Vector3D.new(
					point.x,
					self.cos(ra) * point.y - self.sin(ra) * point.z,
					self.sin(ra) * point.y + self.cos(ra) * point.z
				)
			when :y
				Vector3D.new(
					self.cos(ra) * point.x + self.sin(ra) * point.z,
					point.y,
					-self.sin(ra) * point.x + self.cos(ra) * point.z
				)
			else
				Vector3D.new(
					self.cos(ra) * point.x - self.sin(ra) * point.y,
					self.sin(ra) * point.x + self.cos(ra) * point.y,
					point.z
				)
		end
	end
	
	def self.randomsteps(from, to, step)
		raise ParameterTypeException, "Numeric expected for `from'" if not from.is_a? Numeric
		raise ParameterTypeException, "Numeric expected for `to'" if not to.is_a? Numeric
		raise ParameterTypeException, "Numeric expected for `step'" if not step.is_a? Numeric
		raise ParameterFormatException, "`from' must be smaller than `to'" if from >= to
		
		from, to, step = from.to_f, to.to_f, step.to_f
		space = to - from
		
		raise ParameterFormatException, "The space between `from' and `to' must match `step' at minimum once" if space < step
		
		possible_times = space / step
		rand(possible_times) * step + from
	end
	
	def self.randomway()
		rand(1) == 0 ? -1 : 1
	end
	
	def self.round(value)
		raise ParameterTypeException, "Numeric expected" if not value.is_a? Numeric
		value.round()		
	end
	
	def self.trim(value, min, max)
		raise ParameterTypeException, "Numeric expected for `value'" if not value.is_a? Numeric
		raise ParameterTypeException, "Numeric expected for `min'" if not min.is_a? Numeric
		raise ParameterTypeException, "Numeric expected for `max'" if not max.is_a? Numeric
		
		[max, [min, value].max].min
	end
	
end

module Shape
	
	def self.bounding(shape)
		raise ParameterTypeException, "String expected" if not shape.is_a? String
		
		location_partials = is_valid?(shape)
		raise ParameterFormatException, "Valid Shape expected" if not location_partials
		
		min_x, min_y, max_x, max_y = 0, 0, 0, 0
		if !(shape.include?("b"))
			min_x, min_y, max_x, max_y = *get_loc_boundings(location_partials)
		else
			raise NotImplementedError, "Bezier curves cant calculated yet"
		end
		
		return min_x, min_y, max_x, max_y
	end
	
	def self.ellipse(width, height)
		raise ParameterTypeException, "Integer expected for `width'" if not width.is_a? Integer
		raise ParameterTypeException, "Integer expected for `height'" if not height.is_a? Integer
		
		width2, height2 = width / 2, height / 2
		"m 0 #{height2} b 0 #{height2} 0 0 #{width2} 0 #{width2} 0 #{width} 0 #{width} #{height2} #{width} #{height2} #{width} #{height} #{width2} #{height} #{width2} #{height} 0 #{height} 0 #{height2}"
	end
	
	def self.ring(outer, inner)
		raise ParameterTypeException, "Integer expected for `inner'" if not inner.is_a? Integer
		raise ParameterTypeException, "Integer expected for `outer'" if not outer.is_a? Integer
		raise ParameterFormatException, "`inner' must be greater than `outer'" if outer <= inner
		
		outer2, inner2 = outer * 2, inner * 2
		off = outer - inner
		
		"m 0 #{outer} b 0 #{outer} 0 0 #{outer} 0 #{outer} 0 #{outer2} 0 #{outer2} #{outer} #{outer2} #{outer} #{outer2} #{outer2} #{outer} #{outer2} #{outer} #{outer2} 0 #{outer2} 0 #{outer} m #{off} #{off+inner} b #{off} #{off+inner} #{off} #{off+inner2} #{off+inner} #{off+inner2} #{off+inner} #{off+inner2} #{off+inner2} #{off+inner2} #{off+inner2} #{off+inner} #{off+inner2} #{off+inner} #{off+inner2} #{off} #{off+inner} #{off} #{off+inner} #{off} #{off} #{off} #{off} #{off+inner}"
	end
	
	def self.filter(shape) # &filter
		raise ParameterTypeException, "String expected" if not shape.is_a? String
		raise ParameterFormatException, "Valid Shape expected" if not is_valid?(shape)
		
		shape.gsub!(/(\-?\d+)\s+(\-?\d+)/) {
			new_x, new_y = *yield($1.to_i, $2.to_i)
			if new_x.is_a?(Numeric) && new_y.is_a?(Numeric) then
				"#{new_x.to_i.to_s} #{new_y.to_i.to_s}"
			else
				"#{$1} #{$1}"
			end
		}
		shape
	end
	
	def self.glance(edges, inner, outer)
		raise ParameterTypeException, "Integer expected for `edges'" if not edges.is_a? Integer
		raise ParameterTypeException, "Integer expected for `inner'" if not inner.is_a? Integer
		raise ParameterTypeException, "Integer expected for `outer'" if not outer.is_a? Integer
		
		glance_or_star(edges, inner, outer, :glance)
	end
	
	def self.star(edges, inner, outer)
		raise ParameterTypeException, "Integer expected for `edges'" if not edges.is_a? Integer
		raise ParameterTypeException, "Integer expected for `inner'" if not inner.is_a? Integer
		raise ParameterTypeException, "Integer expected for `outer'" if not outer.is_a? Integer
		
		glance_or_star(edges, inner, outer, :star)
	end
	
	def self.move(shape, x, y)
		raise ParameterTypeException, "String expected for `shape'" if not shape.is_a? String
		raise ParameterFormatException, "Valid Shape expected for `shape'" if not is_valid?(shape)
		raise ParameterTypeException, "Integer expected for `x'" if not x.is_a? Integer
		raise ParameterTypeException, "Integer expected for `y'" if not y.is_a? Integer
		
		self.filter(shape) { |l, r| [l+x, r+y] }
	end
	
	def self.rectangle(width, height)
		raise ParameterTypeException, "Integer expected for `width'" if not width.is_a? Integer
		raise ParameterTypeException, "Integer expected for `height'" if not height.is_a? Integer
		
		"m 0 0 l #{width} 0 l #{width} #{height} l 0 #{height} l 0 0"
	end
	
	def self.heart(size, offset)
		raise ParameterTypeException, "Numeric expected for `size'" if not size.is_a? Numeric
		raise ParameterTypeException, "Numeric expected for `offset'" if not offset.is_a? Numeric
		
		template = "m 15 30 b 27 22 30 18 30 14 b 30 8 22 0 15 10 b 8 0 0 8 0 14 b 0 18 3 22 15 30"
		rebuild = template.gsub(/\d+/) { |m| (m.to_f / 30 * size).round }
		rebuild.gsub(/\-?\d+$/) { |m| m.to_i + offset }
	end
	
	def self.triangle(size)
		raise ParameterTypeException, "Integer expected" if not size.is_a? Integer
		
		h = (Math.sqrt(3) * size / 2).round
		base = (-h / 6.to_f).round
		
		"m #{size / 2} #{base} l #{size} #{base + h} 0 #{base + h} #{size / 2} #{base}"
	end

	def self.split(shape, line_length = nil)
		raise NotImplementedError
	end
	
	def self.tooutline(shape, size)
		raise ParameterTypeException, "String expected for `shape'" if not shape.is_a? String
		raise ParameterFormatException, "Valid Shape expected for `shape'" if not is_valid?(shape)
		raise ParameterFormatException, "Shape must not contain bezier curves for `shape'" if shape =~ /b/
		raise ParameterTypeException, "Integer expected for `size'" if not size.is_a? Integer
		
		figures = []
		first = true
		shape.split("m").each { |figure|
			c_figure = []
			if first
				first = false
				next
			end
			figure = "m" + figure
			partials = get_location_partials(figure)
			raise ParameterFormatException, "At least one figure hasn't enough points" if partials.size < 6
			
			(partials.size / 2).times {
				c_figure << partials[0..1]
				2.times { partials.shift }
			}
			figures << c_figure
		}
		
		figures.each_index { |fi|
			old_figure, old_size = figures[fi], figures[fi].size
			new_figure = [], 0
			
			old_figure.each_index { |pi|
				
			}
		}
		puts figures
	end
	
	private_class_method def self.is_valid?(shape)
		return false if shape == ""									# Empty string is not a valid shape
		return false if /[^mlb\s\-\d]/.match(shape)					# String with other than this elements is invalid
		return false if /[mbl](\s?\-?\d+\s?){1}[mbl]/.match(shape)	# Shape with single number between move, bezier or line is invalid
		
		coords = get_location_partials(shape)
		return false if coords.size % 2 != 0						# Shape with odd number of location partials is invalid
		return coords
	end
	
	private_class_method def self.get_location_partials(original_shape)
		shape = String.new(original_shape)
		shape.gsub!(/[bml]/, "")
		partials = shape.squeeze(' ').split(" ").map(&:to_i)
		partials
	end
	
	private_class_method def self.get_loc_boundings(shape_or_partials)
		partials = shape_or_partials.is_a?(Array) ? shape_or_partials : get_location_partials(shape_or_partials)
		
		m_left = true
		left, right = [], []
		partials.each { |lp|
			if m_left then left << lp else right << lp end
			m_left = !m_left
		}
		
		return left.min, right.min, left.max, right.max
	end
	
	private_class_method def self.glance_or_star(edges, inner, outer, type)
		ad = type == :glance ? "b" : "l"
		shape_arr = ["m 0 #{-outer} #{ad}"]
		for i in 1..edges
			vi = Math.rotate(Vector3D.new(0, -inner, 0), :z, ((i - 0.5).to_f / edges) * 360)
			vo = Math.rotate(Vector3D.new(0, -outer, 0), :z, (i.to_f / edges) * 360)
			
			shape_ad = [vi.x, vi.y, vo.x, vo.y]
			shape_ad.insert(2, vi.x, vi.y) if type == :glance
			shape_ad = shape_ad.map() { |e| e.to_i }
			shape_arr << shape_ad.join(' ')
		end
		shape = shape_arr.join(" ")
		
		min_x, min_y = *get_loc_boundings(shape)
		shape = self.move(shape, -min_x, -min_y)
	end
	
end

module Utils
	
	def self.interpolate(percent, from, to, speed=1)
		raise ParameterTypeException, "Numeric expected for `percent'" if not percent.is_a? Numeric
		raise ParameterTypeException, "Numeric or String expected for `from'" if not from.is_a?(Numeric) || from.is_a?(String)
		raise ParameterTypeException, "Numeric or String expected for `to'" if not to.is_a?(Numeric) || to.is_a?(String)
		raise ParameterTypeException, "Numeric or Symbol expected for `speed'" if not speed.is_a?(Numeric) || speed.is_a?(Symbol)
		raise ParameterFormatException, "`speed' must be :increase, :decrease or a numeric value" if speed.is_a?(Symbol) && ![:increase, :decrease].include?(speed)
		
		if (from.class != to.class)
			raise ParameterTypeException, "`from' and `to' must be of same type (String or Numeric)" if from.is_a?(String) || to.is_a?(String)
		end
		
		if speed.is_a?(Numeric)
			percent **= speed
		else
			percent = (Math.sin( -Math::PI / 2 + percent * Math::PI * 2) + 1) / 2
			percent = 1 - percent if speed == :decrease
		end
		
		if from.is_a?(Numeric)
			result = from + (to - from) * percent
			return from.is_a?(Integer) && to.is_a?(Integer) ? result.to_i : result
		else
			if from =~ /\&H([0-9a-fA-F]{2})\&/ && to =~ /\&H([0-9a-fA-F]{2})\&/ # Alpha
				left = Converts.ass_to_a(from)
				right = Converts.ass_to_a(to)
				
				return Converts.a_to_ass((right - left) * percent + left)
			elsif from =~ /\&H([0-9a-fA-F]{2})([0-9a-fA-F]{2})([0-9a-fA-F]{2})\&/ && 
				to =~ /\&H([0-9a-fA-F]{2})([0-9a-fA-F]{2})([0-9a-fA-F]{2})\&/ # ASS Color
				lr, lg, lb = Converts.ass_to_rgb(from)
				rr, rg, rb = Converts.ass_to_rgb(to)
				
				return Converts.rgb_to_ass(
					((rr - lr) * percent + lr).to_i,
					((rg - lg) * percent + lg).to_i,
					((rb - lb) * percent + lb).to_i
				)
			else
				raise ParameterFormatException, "`from' and `to' must be an ASS alpha value or an ASS color value and booth from same type"
			end
		end
	end
	
	def self.frames(from, to, frame_duration) # &block
		raise ParameterTypeException, "Numeric expected for `from'" if not from.is_a? Numeric
		raise ParameterTypeException, "Numeric expected for `to'" if not to.is_a? Numeric
		raise ParameterTypeException, "Numeric expected for `frame_duration'" if not frame_duration.is_a? Numeric
		raise ParameterFormatException, "`frame_duration' must be greater than zero" if frame_duration <= 0
		raise BlockMissingException, "Block expected" if not block_given?
		
		current_start, i, n = from, 1, ((to.to_f - from) / frame_duration).ceil
		
		loop do
			current_end = [current_start + frame_duration, to].min
			
			yield(current_start, current_end, i, n)
			
			break if current_end == to
			current_start = current_end
			i += 1
		end
	end
	
	def self.text_extends(text, style)
		raise NotImplementedError
	end
	
end

#Shape.tooutline("m 0 0 l 100 0 100 50 0 50", 5)